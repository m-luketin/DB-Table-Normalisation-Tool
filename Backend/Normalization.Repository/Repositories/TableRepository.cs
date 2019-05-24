using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Factory;
using Normalization.Repository.Interfaces;

namespace Normalization.Repository.Repositories
{
    public class TableRepository : IRepository
    {
        private readonly TableContext _tableContext;

        public TableRepository()
        {
            _tableContext = ContextFactory.CreateTableContext();
        }
        public IQueryable Read()
        {
            return _tableContext.Tables;
        }
        public void Create(ref IEntity entity)
        {
            var table = _tableContext.Tables.Add(new Table(((Table)entity).Name));
            _tableContext.SaveChanges();
            entity = table.Entity;
        }

        public void Delete(IEntity entity)
        {
            _tableContext.Tables.Remove((Table)entity);
            _tableContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
            _tableContext.SaveChanges();
        }

        public IEntity Edit(IEntity entity)
        {
            var tableNew = (Table) entity;
            var table = (Table) GetById(entity.Id);
            table.Name = tableNew.Name;
            table.TableAttributes = tableNew.TableAttributes;
            _tableContext.Tables.Update(table);
            _tableContext.SaveChanges();
            return table;
        }

        public IEntity GetById(int id)
        {
            return _tableContext.Tables.Find(id);
        }
    }
}

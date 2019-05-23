using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Interfaces;

namespace Normalization.Repository.Repositories
{
    public class TableRepository : IRepository
    {
        private readonly TableContext _tableContext;

        public TableRepository()
        {
            _tableContext = new TableContext();
        }

        public IEntity Create(IEntity entity)
        {
            var table = (Table) entity;
            _tableContext.Tables.Add(table);
            _tableContext.SaveChanges();
            return table;
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
            var table = (Table) GetById(entity.PrimaryId);
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

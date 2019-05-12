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

        public void Create(IEntity entity)
        {
            _tableContext.Tables.Add((Table)entity);
            _tableContext.SaveChanges();
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

        public void Edit(IEntity entity)
        {
            Delete(entity.PrimaryId);
            Create(entity);
            _tableContext.SaveChanges();
        }

        public IEntity GetById(int id)
        {
            return _tableContext.Tables.Find(id);
        }
    }
}

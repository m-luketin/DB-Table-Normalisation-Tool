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
    public class TableAttributeRepository : IRepository
    {
        private readonly TableAttributeContext _tableAttributeContext;
        public TableAttributeRepository()
        {
            _tableAttributeContext = new TableAttributeContext();
        }

        public void Create(IEntity entity)
        {
            _tableAttributeContext.TableAttributes.Add((TableAttribute)entity);
            _tableAttributeContext.SaveChanges();
        }

        public void Delete(IEntity entity)
        {
            _tableAttributeContext.TableAttributes.Remove((TableAttribute)entity);
            _tableAttributeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
            _tableAttributeContext.SaveChanges();
        }

        public void Edit(IEntity entity)
        {
            Delete(entity.PrimaryId);
            Create(entity);
            _tableAttributeContext.SaveChanges();
        }

        public IEntity GetById(int id)
        {
            return _tableAttributeContext.TableAttributes.Find(id);
        }
    }
}

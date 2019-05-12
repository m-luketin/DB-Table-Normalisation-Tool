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
    public class TableAttributeCollectionRepository : IRepository
    {
        private readonly TableAttributeCollectionContext _tableAttributeCollectionContext;

        public TableAttributeCollectionRepository()
        {
            _tableAttributeCollectionContext = new TableAttributeCollectionContext();
        }

        public void Create(IEntity entity)
        {
            _tableAttributeCollectionContext.TableAttributeCollections.Add((TableAttributeCollection)entity);
            _tableAttributeCollectionContext.SaveChanges();
        }

        public void Delete(IEntity entity)
        {
            _tableAttributeCollectionContext.TableAttributeCollections.Remove((TableAttributeCollection)entity);
            _tableAttributeCollectionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
            _tableAttributeCollectionContext.SaveChanges();
        }

        public void Edit(IEntity entity)
        {
            Delete(entity.PrimaryId);
            Create(entity);
            _tableAttributeCollectionContext.SaveChanges();
        }

        public IEntity GetById(int id)
        {
            return _tableAttributeCollectionContext.TableAttributeCollections.Find(id);
        }
    }
}

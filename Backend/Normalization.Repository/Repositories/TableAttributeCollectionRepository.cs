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

        public IEntity Create(IEntity entity)
        {
            var tableAttributeCollection = (TableAttributeCollection) entity;
            _tableAttributeCollectionContext.TableAttributeCollections.Add(tableAttributeCollection);
            _tableAttributeCollectionContext.SaveChanges();
            return tableAttributeCollection;
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

        public IEntity Edit(IEntity entity)
        {
            var tableAttributeCollectionNew = (TableAttributeCollection) entity;
            var tableAttributeCollection = (TableAttributeCollection) GetById(entity.PrimaryId);
            tableAttributeCollection.AttributeCollection = tableAttributeCollectionNew.AttributeCollection;
            tableAttributeCollection.TableAttribute = tableAttributeCollection.TableAttribute;
            _tableAttributeCollectionContext.TableAttributeCollections.Update(tableAttributeCollection);
            _tableAttributeCollectionContext.SaveChanges();
            return tableAttributeCollection;
        }

        public IEntity GetById(int id)
        {
            return _tableAttributeCollectionContext.TableAttributeCollections.Find(id);
        }
    }
}

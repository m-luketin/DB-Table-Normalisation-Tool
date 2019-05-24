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
    public class TableAttributeCollectionRepository : IRepository
    {
        private readonly TableAttributeCollectionContext _tableAttributeCollectionContext;

        public TableAttributeCollectionRepository()
        {
            _tableAttributeCollectionContext = new TableAttributeCollectionContext();
        }
        public IQueryable Read()
        {
            return _tableAttributeCollectionContext.TableAttributeCollections;
        }
        public void Create(ref IEntity entity)
        {
            var tableAttributeCollectionNew = (TableAttributeCollection) entity;
            var attributeCollection = _tableAttributeCollectionContext.AttributeCollections
                .Find(tableAttributeCollectionNew.AttributeCollection.Id);
            var tableAttribute = _tableAttributeCollectionContext.TableAttributes
                .Find(tableAttributeCollectionNew.TableAttribute.Id);
            var tableAttributeCollection =_tableAttributeCollectionContext.TableAttributeCollections.Add(
                new TableAttributeCollection(attributeCollection,tableAttribute));

            _tableAttributeCollectionContext.SaveChanges();
            entity = tableAttributeCollection.Entity;
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
            var tableAttributeCollection = (TableAttributeCollection) GetById(entity.Id);
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

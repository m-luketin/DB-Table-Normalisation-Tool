using System;
using System.Linq;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Interfaces;

namespace Normalization.Repository.Repositories
{
    public class AttributeCollectionRepository : IRepository
    {
        private readonly ConfigurationContext _attributeCollectionContext;

        public AttributeCollectionRepository() 
        {
            _attributeCollectionContext = new ConfigurationContext();
        }

        public IQueryable Read()
        {
            return _attributeCollectionContext.AttributeCollections;
        }

        public void Create(ref IEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var attributeCollection = _attributeCollectionContext.AttributeCollections.Add(new AttributeCollection());
            _attributeCollectionContext.SaveChanges();
            entity = attributeCollection.Entity;
        }

        public void Delete(IEntity entity)
        {
            _attributeCollectionContext.AttributeCollections.Remove((AttributeCollection)entity);
            _attributeCollectionContext.SaveChanges();
        }

        public void DeleteByTable(int id)
        {
            var attributesToDelete = _attributeCollectionContext.AttributeCollections.Where
            (
                attributeCollection => attributeCollection.TableAttributeCollections.Any
                (
                    tableAttributeCol => tableAttributeCol.TableAttribute.TableId == id
                )
            );
            _attributeCollectionContext.AttributeCollections.RemoveRange(attributesToDelete);
            _attributeCollectionContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
            _attributeCollectionContext.SaveChanges();
        }

        public IEntity Edit(IEntity entity)
        {
            var attributeCollectionNew = (AttributeCollection) entity;
            var attributeCollection = (AttributeCollection)GetById(entity.Id);
            attributeCollection.DependencyElements = attributeCollectionNew.DependencyElements;
            attributeCollection.KeyGroup = attributeCollectionNew.KeyGroup;
            attributeCollection.TableAttributeCollections = attributeCollectionNew.TableAttributeCollections;
            _attributeCollectionContext.AttributeCollections.Update(attributeCollection);
            _attributeCollectionContext.SaveChanges();
            return attributeCollection;
        }

        public IEntity GetById(int id)
        {
            return _attributeCollectionContext.AttributeCollections.Find(id);
        }
    }
}

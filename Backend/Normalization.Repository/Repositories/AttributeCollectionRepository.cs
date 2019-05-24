using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Factory;
using Normalization.Repository.Interfaces;
using Attribute = Normalization.Data.Models.Attribute;

namespace Normalization.Repository.Repositories
{
    public class AttributeCollectionRepository : IRepository
    {
        private readonly AttributeCollectionContext _attributeCollectionContext;

        public AttributeCollectionRepository() 
        {
            _attributeCollectionContext = ContextFactory.CreateAttributeCollectionContext();
        }

        public ICollection<IQueryable> Read()
        {
            return (ICollection<IQueryable>)_attributeCollectionContext.AttributeCollections.ToList();
        }

        public void Create(ref IEntity entity)
        {
            var attributeCollection = _attributeCollectionContext.AttributeCollections.Add(new AttributeCollection());
            _attributeCollectionContext.SaveChanges();
            entity = attributeCollection.Entity;
        }

        public void Delete(IEntity entity)
        {
            _attributeCollectionContext.AttributeCollections.Remove((AttributeCollection)entity);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Interfaces;
using Attribute = Normalization.Data.Models.Attribute;

namespace Normalization.Repository.Repositories
{
    public class AttributeCollectionRepository : IRepository
    {
        private readonly AttributeCollectionContext _attributeCollectionContext;

        public AttributeCollectionRepository() 
        {
            _attributeCollectionContext = new AttributeCollectionContext();
        }

        public void Create(IEntity entity)
        {
            _attributeCollectionContext.AttributeCollections.Add((AttributeCollection)entity);
            _attributeCollectionContext.SaveChanges();
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

        public void Edit(IEntity entity)
        {
            Delete(entity.PrimaryId);
            Create(entity);
            _attributeCollectionContext.SaveChanges();
        }

        public IEntity GetById(int id)
        {
            return _attributeCollectionContext.AttributeCollections.Find(id);
        }
    }
}

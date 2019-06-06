using System.Linq;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Interfaces;
using Attribute = Normalization.Data.Models.Attribute;

namespace Normalization.Repository.Repositories
{
    public class AttributeRepository : IRepository
    {
        private readonly ConfigurationContext _attributeContext;

        public AttributeRepository()
        {
            _attributeContext = new ConfigurationContext();
        }

        public IQueryable Read()
        {
            return _attributeContext.Attributes;
        }

        public void Create(ref IEntity entity)
        {
            var attributeNew = (Attribute) entity;
            var attribute=_attributeContext.Attributes.Add(new Attribute(attributeNew.ColumnName));
            _attributeContext.SaveChanges();
            entity = attribute.Entity;
        }

        public void Delete(IEntity entity)
        {
            _attributeContext.Attributes.Remove((Attribute) entity);
            _attributeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
            _attributeContext.SaveChanges();
        }

        public IEntity Edit(IEntity entity)
        {
            var attributeNew = (Attribute) entity;
            var attribute = (Attribute) GetById(entity.Id);
            attribute.ColumnName = attributeNew.ColumnName;
            attribute.TableAttributes = attributeNew.TableAttributes;
            _attributeContext.Attributes.Update(attribute);
            _attributeContext.SaveChanges();
            return attribute;
        }

        public IEntity GetById(int id)
        {
            return _attributeContext.Attributes.Find(id);
        }
    }
}

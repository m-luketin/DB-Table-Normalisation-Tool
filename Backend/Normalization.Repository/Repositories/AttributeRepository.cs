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
    public class AttributeRepository : IRepository
    {
        private readonly AttributeContext _attributeContext;

        public AttributeRepository()
        {
            _attributeContext = new AttributeContext();
        }

        public ICollection<IQueryable> Read()
        {
            return (ICollection<IQueryable>)_attributeContext.Attributes.ToList();
        }

        public IEntity Create(IEntity entity)
        {
            var attributeNew = (Attribute) entity;
            _attributeContext.Attributes.Add(attributeNew);
            _attributeContext.SaveChanges();
            return attributeNew;
        }

        public void Delete(IEntity entity)
        {
            _attributeContext.Attributes.Remove((Data.Models.Attribute)entity);
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
            var attribute = (Attribute)GetById(entity.PrimaryId);
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

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

        public void Create(IEntity entity)
        {
            _attributeContext.Attributes.Add((Data.Models.Attribute)entity);
            _attributeContext.SaveChanges();
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

        public void Edit(IEntity entity)
        {
            Delete(entity.PrimaryId);
            Create(entity);
            _attributeContext.SaveChanges();
        }

        public IEntity GetById(int id)
        {
            return _attributeContext.Attributes.Find(id);
        }
    }
}

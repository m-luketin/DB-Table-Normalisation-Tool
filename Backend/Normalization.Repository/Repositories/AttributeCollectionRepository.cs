﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Interfaces;
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
            throw new NotImplementedException();
        }

        public void Delete(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEntity GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class KeyGroupRepository : IRepository
    {
        private readonly KeyGroupContext _keyGroupContext;

        public KeyGroupRepository()
        {
            _keyGroupContext = new KeyGroupContext();
        }

        public IEntity Create(IEntity entity)
        {
            var keyGroup = (KeyGroup) entity;
            _keyGroupContext.KeyGroups.Add(keyGroup);
            _keyGroupContext.SaveChanges();
            return keyGroup;
        }

        public void Delete(IEntity entity)
        {
            _keyGroupContext.KeyGroups.Remove((KeyGroup)entity);
            _keyGroupContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
            _keyGroupContext.SaveChanges();
        }

        public IEntity Edit(IEntity entity)
        {
            var keyGroupNew = (KeyGroup) entity;
            var keyGroup = (KeyGroup) GetById(entity.PrimaryId);
            keyGroup.AttributeCollection = keyGroupNew.AttributeCollection;
            _keyGroupContext.KeyGroups.Update(keyGroup);
            _keyGroupContext.SaveChanges();
            return keyGroup;
        }

        public IEntity GetById(int id)
        {
            return _keyGroupContext.KeyGroups.Find(id);
        }
    }
}

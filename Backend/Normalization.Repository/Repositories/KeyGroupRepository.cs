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

        public void Create(IEntity entity)
        {
            _keyGroupContext.KeyGroups.Add((KeyGroup)entity);
            _keyGroupContext.SaveChanges();
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

        public void Edit(IEntity entity)
        {
            Delete(entity.PrimaryId);
            Create(entity);
            _keyGroupContext.SaveChanges();
        }

        public IEntity GetById(int id)
        {
            return _keyGroupContext.KeyGroups.Find(id);
        }
    }
}

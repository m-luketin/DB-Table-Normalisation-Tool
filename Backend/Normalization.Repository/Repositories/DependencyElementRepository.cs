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
    public class DependencyElementRepository : IRepository
    {
        private readonly DependencyElementContext _dependencyElementContext;

        public DependencyElementRepository()
        {
            _dependencyElementContext = new DependencyElementContext();
        }

        public void Create(IEntity entity)
        {
            _dependencyElementContext.DependencyElements.Add((DependencyElement)entity);
            _dependencyElementContext.SaveChanges();
        }

        public void Delete(IEntity entity)
        {
            _dependencyElementContext.DependencyElements.Remove((DependencyElement)entity);
            _dependencyElementContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
            _dependencyElementContext.SaveChanges();
        }

        public void Edit(IEntity entity)
        {
            Delete(entity.PrimaryId);
            Create(entity);
            _dependencyElementContext.SaveChanges();
        }

        public IEntity GetById(int id)
        {
            return _dependencyElementContext.DependencyElements.Find(id);
        }
    }
}

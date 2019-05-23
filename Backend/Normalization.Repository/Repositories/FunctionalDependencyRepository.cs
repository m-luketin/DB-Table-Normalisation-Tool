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
    public class FunctionalDependencyRepository : IRepository
    {
        private readonly FunctionalDependencyContext _functionalDependencyContext;

        public FunctionalDependencyRepository()
        {
            _functionalDependencyContext = new FunctionalDependencyContext();
        }
        public ICollection<IQueryable> Read()
        {
            return (ICollection<IQueryable>)_functionalDependencyContext.FunctionalDependencies.ToList();
        }
        public IEntity Create(IEntity entity)
        {
            var functionalDependency = (FunctionalDependency) entity;
            _functionalDependencyContext.FunctionalDependencies.Add(functionalDependency);
            _functionalDependencyContext.SaveChanges();
            return functionalDependency;
        }

        public void Delete(IEntity entity)
        {
            _functionalDependencyContext.FunctionalDependencies.Remove((FunctionalDependency)entity);
            _functionalDependencyContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
            _functionalDependencyContext.SaveChanges();
        }

        public IEntity Edit(IEntity entity)
        {
            var functionalDependencyNew = (FunctionalDependency) entity;
            var functionalDependency = (FunctionalDependency) GetById(entity.PrimaryId);
            _functionalDependencyContext.FunctionalDependencies.Update(functionalDependency);
            _functionalDependencyContext.SaveChanges();
            return functionalDependency;
        }

        public IEntity GetById(int id)
        {
            return _functionalDependencyContext.FunctionalDependencies.Find(id);
        }
    }
}

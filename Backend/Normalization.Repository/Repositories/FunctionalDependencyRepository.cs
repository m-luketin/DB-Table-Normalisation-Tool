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

        public void Create(IEntity entity)
        {
            _functionalDependencyContext.FunctionalDependencies.Add((FunctionalDependency)entity);
            _functionalDependencyContext.SaveChanges();
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

        public void Edit(IEntity entity)
        {
            Delete(entity.PrimaryId);
            Create(entity);
            _functionalDependencyContext.SaveChanges();
        }

        public IEntity GetById(int id)
        {
            return _functionalDependencyContext.FunctionalDependencies.Find(id);
        }
    }
}

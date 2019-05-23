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

        public ICollection<IQueryable> Read()
        {
            return (ICollection<IQueryable>)_dependencyElementContext.DependencyElements.ToList();
        }

        public IEntity Create(IEntity entity)
        {
            var dependencyElement = (DependencyElement) entity;
            _dependencyElementContext.DependencyElements.Add(dependencyElement);
            _dependencyElementContext.SaveChanges();
            return dependencyElement;
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

        public IEntity Edit(IEntity entity)
        {
            var dependencyElementNew = (DependencyElement) entity;
            var dependencyElement = (DependencyElement) GetById(entity.PrimaryId);

            dependencyElement.AttributeCollection = dependencyElementNew.AttributeCollection;
            dependencyElement.FunctionalDependency = dependencyElementNew.FunctionalDependency;
            dependencyElement.IsLeft = dependencyElementNew.IsLeft;

            _dependencyElementContext.DependencyElements.Update(dependencyElement);
            _dependencyElementContext.SaveChanges();
            return dependencyElement;
        }

        public IEntity GetById(int id)
        {
            return _dependencyElementContext.DependencyElements.Find(id);
        }

        public IEntity CreateWithAttributeCollection(bool isLeft, IEntity attributeCollection,IEntity functionalDependency)
        {
            var dependencyElement = new DependencyElement
            {
                IsLeft = isLeft,
                AttributeCollection = (AttributeCollection) attributeCollection,
                FunctionalDependency = (FunctionalDependency)functionalDependency
            };
            _dependencyElementContext.DependencyElements.Add(dependencyElement);
            _dependencyElementContext.SaveChanges();
            return dependencyElement;
        }
    }
}

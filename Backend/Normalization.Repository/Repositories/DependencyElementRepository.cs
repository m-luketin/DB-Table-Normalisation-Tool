using System.Linq;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Interfaces;

namespace Normalization.Repository.Repositories
{
    public class DependencyElementRepository : IRepository
    {
        private readonly ConfigurationContext _dependencyElementContext;

        public DependencyElementRepository()
        {
            _dependencyElementContext = new ConfigurationContext();
        }

        public IQueryable Read()
        {
            return _dependencyElementContext.DependencyElements;
        }

        public void Create(ref IEntity entity)
        {
            var dependencyElementNew = (DependencyElement) entity;
            var attributeCollection = _dependencyElementContext.AttributeCollections.Find
                (
                    dependencyElementNew.AttributeCollection.Id
                );
            var functionalDependency = _dependencyElementContext.FunctionalDependencies.Find
                (
                    dependencyElementNew.FunctionalDependency.Id
                );
            var dependencyElement =_dependencyElementContext.DependencyElements.Add
                (
                    new DependencyElement
                    (
                        attributeCollection,
                        functionalDependency,
                        dependencyElementNew.IsLeft
                    )
                );
            _dependencyElementContext.SaveChanges();
            entity = dependencyElement.Entity;
        }

        public void Delete(IEntity entity)
        {
            _dependencyElementContext.DependencyElements.Remove((DependencyElement) entity);
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
            var dependencyElement = (DependencyElement) GetById(entity.Id);

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

        public IEntity CreateWithAttributeCollection
        (
            bool isLeft,
            IEntity attributeCollection,
            IEntity functionalDependency
        )
        {
            var dependencyElement = new DependencyElement
            {
                IsLeft = isLeft,
                AttributeCollection = _dependencyElementContext.AttributeCollections.Find
                    (
                        attributeCollection.Id
                    ),
                FunctionalDependency = _dependencyElementContext.FunctionalDependencies.Find
                    (
                        functionalDependency.Id
                    )
            };
            _dependencyElementContext.DependencyElements.Add(dependencyElement);
            _dependencyElementContext.SaveChanges();
            return dependencyElement;
        }
    }
}

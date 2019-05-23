using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Normalization.Repository.Interfaces;
using Normalization.Repository.Repositories;

namespace Normalization.Maps.Factory
{
    public static class RepositoryFactory
    {
        public static IRepository CreateTableRepository()
        {
            return new TableRepository();
        }

        public static DependencyElementRepository CreateDependencyElementRepository()
        {
            return new DependencyElementRepository();
        }

        public static IRepository CreateAttributeRepository()
        {
            return new AttributeRepository();
        }

        public static IRepository CreateAttributeCollectionRepository()
        {
            return new AttributeCollectionRepository();
        }

        public static IRepository CreateFunctionalDependencyRepository()
        {
            return new FunctionalDependencyRepository();
        }

        public static IRepository CreateKeyGroupRepository()
        {
            return new KeyGroupRepository();
        }

        public static TableAttributeRepository CreateTableAttributeRepository()
        {
            return new TableAttributeRepository();
        }

        public static IRepository CreateTableAttributeCollectionRepository()
        {
            return new TableAttributeCollectionRepository();
        }
    }
}

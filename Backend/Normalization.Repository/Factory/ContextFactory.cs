using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;

namespace Normalization.Repository.Factory
{
    public static class ContextFactory
    {
        public static AttributeContext CreateAttributeContext()
        {
            return new AttributeContext();
        }

        public static AttributeCollectionContext CreateAttributeCollectionContext()
        {
            return new AttributeCollectionContext();
        }

        public static DependencyElementContext CreateDependencyElementContext()
        {
            return new DependencyElementContext();
        }

        public static FunctionalDependencyContext CreateFunctionalDependencyContext()
        {
            return new FunctionalDependencyContext();
        }

        public static KeyGroupContext CreateKeyGroupContext()
        {
            return new KeyGroupContext();
        }

        public static TableContext CreateTableContext()
        {
            return new TableContext();
        }

        public static TableAttributeContext CreateTableAttributeContext()
        {
            return new TableAttributeContext();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.Data.Models
{
    public class DependencyElement : IEntity
    {
        public int Id { get; set; }
        public AttributeCollection AttributeCollection { get; set; }
        public int AttributeCollectionId { get; set; }
        public FunctionalDependency FunctionalDependency { get; set; }
        public int FunctionalDependencyId { get; set; }
        public bool IsLeft { get; set; }

        public DependencyElement()
        {
            
        }
        public DependencyElement(AttributeCollection attributeCollection, FunctionalDependency functionalDependencies, bool isLeft)
        {
            AttributeCollection = attributeCollection;
            AttributeCollectionId = attributeCollection.Id;
            FunctionalDependency = functionalDependencies;
            FunctionalDependencyId = functionalDependencies.Id;
            IsLeft = isLeft;
        }

    }
}

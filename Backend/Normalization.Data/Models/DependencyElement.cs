using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.Data.Models
{
    public class DependencyElement : IEntity
    {
        public int PrimaryId { get; set; }
        public AttributeCollection AttributeCollection { get; set; }
        public FunctionalDependency FunctionalDependency { get; set; }
        public bool IsLeft { get; set; }

        public DependencyElement()
        {
            
        }
        public DependencyElement(AttributeCollection attributeCollection, FunctionalDependency functionalDependencies, bool isLeft)
        {
            AttributeCollection = attributeCollection;
            FunctionalDependency = functionalDependencies;
            IsLeft = isLeft;
        }

    }
}

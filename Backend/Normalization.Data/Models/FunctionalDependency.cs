using System.Collections.Generic;

namespace Normalization.Data.Models
{
    public class FunctionalDependency : IEntity
    {
        public int Id { get; set; }
        public ICollection<DependencyElement> DependencyElements { get; set; }

        public FunctionalDependency()
        {
            
        }

        public FunctionalDependency(ICollection<DependencyElement> dependencyElement)
        {
            DependencyElements = dependencyElement;
        }
    }
}

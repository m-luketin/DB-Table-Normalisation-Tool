using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.Data.Models
{
    public class FunctionalDependency : IEntity
    {
        public int PrimaryId { get; set; }
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

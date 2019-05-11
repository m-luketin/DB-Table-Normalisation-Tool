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
        public DependencyElement DependencyElement { get; set; }

        public FunctionalDependency()
        {
            
        }
        public FunctionalDependency(DependencyElement dependencyElement)
        {
            DependencyElement = dependencyElement;
        }

    }
}

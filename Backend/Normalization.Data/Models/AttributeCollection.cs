using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.Data.Models
{
    public class AttributeCollection : IEntity
    {
        public int PrimaryId { get; set; }
        public ICollection<TableAttributeCollection> TableAttributeCollections { get; set; }
        public ICollection<KeyGroup> KeyGroup { get; set; }
        public ICollection<DependencyElement> FunctionalDependency { get; set; }

        public AttributeCollection()
        {
            
        }

        public AttributeCollection(ICollection<DependencyElement> functionalDependency)
        {
            FunctionalDependency = functionalDependency;
        }
        public AttributeCollection(ICollection<KeyGroup> keyGroup)
        {
            KeyGroup = keyGroup;
        }
        public AttributeCollection(ICollection<TableAttributeCollection> tableAttributeCollections)
        {
            TableAttributeCollections = tableAttributeCollections;
        }
        public AttributeCollection(ICollection<TableAttributeCollection> tableAttributeCollections, ICollection<KeyGroup> keyGroup, ICollection<DependencyElement> functionalDependency)
        {
            TableAttributeCollections = tableAttributeCollections;
            KeyGroup = keyGroup;
            FunctionalDependency = functionalDependency;
        }

    }
}

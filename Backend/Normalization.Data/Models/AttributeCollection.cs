using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.Data.Models
{
    public class AttributeCollection : IEntity
    {
        public int Id { get; set; }
        public ICollection<TableAttributeCollection> TableAttributeCollections { get; set; }
        public ICollection<KeyGroup> KeyGroup { get; set; }
        public ICollection<DependencyElement> DependencyElements { get; set; }

        public AttributeCollection()
        {
            
        }

        public AttributeCollection(ICollection<DependencyElement> dependencyElements)
        {
            DependencyElements = dependencyElements;
        }
        public AttributeCollection(ICollection<KeyGroup> keyGroup)
        {
            KeyGroup = keyGroup;
        }
        public AttributeCollection(ICollection<TableAttributeCollection> tableAttributeCollections)
        {
            TableAttributeCollections = tableAttributeCollections;
        }
        public AttributeCollection(ICollection<TableAttributeCollection> tableAttributeCollections, ICollection<KeyGroup> keyGroup, ICollection<DependencyElement> dependencyElements)
        {
            TableAttributeCollections = tableAttributeCollections;
            KeyGroup = keyGroup;
            DependencyElements = dependencyElements;
        }

    }
}

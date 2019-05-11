using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.Data.Models
{
    public class KeyGroup : IEntity
    {
        public int PrimaryId { get; set; }
        public AttributeCollection AttributeCollection { get; set; }

        public KeyGroup()
        {
            
        }
        public KeyGroup(AttributeCollection attributeCollection)
        {
            AttributeCollection = attributeCollection;
        }

    }
}

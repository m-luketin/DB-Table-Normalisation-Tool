using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.Data.Models
{
    public class TableAttribute : IEntity
    {
        public int PrimaryId { get; set; }
        public Table Tables { get; set; }
        public Attribute Attributes { get; set; }
        public ICollection<TableAttributeCollection> TableAttributeCollections { get; set; }

        public TableAttribute()
        {
            
        }

        public TableAttribute(Table tables, Attribute attributes)
        {
            Tables = tables;
            Attributes = attributes;
        }
        public TableAttribute(Table tables, Attribute attributes, ICollection<TableAttributeCollection> tableAttributeCollections)
        {
            Tables = tables;
            Attributes = attributes;
            TableAttributeCollections = tableAttributeCollections;
        }

    }
}

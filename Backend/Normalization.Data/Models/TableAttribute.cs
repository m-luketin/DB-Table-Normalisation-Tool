using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.Data.Models
{
    public class TableAttribute : IEntity
    {
        public int Id { get; set; }
        public Table Table { get; set; }
        public int TableId { get; set; }
        public Attribute Attribute { get; set; }
        public int AttributeId { get; set; }
        public ICollection<TableAttributeCollection> TableAttributeCollection { get; set; }

        public TableAttribute()
        {
            
        }

        public TableAttribute(Table table, Attribute attribute)
        {
            Table = table;
            TableId = table.Id;
            Attribute = attribute;
            AttributeId = attribute.Id;
        }

        public TableAttribute(Table table, Attribute attribute, ICollection<TableAttributeCollection> tableAttributeCollection)
        {
            Table = table;
            Attribute = attribute;
            TableAttributeCollection = tableAttributeCollection;
        }

    }
}

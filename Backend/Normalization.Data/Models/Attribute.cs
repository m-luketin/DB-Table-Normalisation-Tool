using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Normalization.Data.Models
{
    public class Attribute : IEntity
    {
        public int PrimaryId { get; set; }
        public string ColumnName { get; set; }
        public ICollection<TableAttribute> TableAttributes { get; set; }

        public Attribute()
        {
            
        }
        public Attribute(string columnName, ICollection<TableAttribute> tableAttributes)
        {
            ColumnName = columnName;
            TableAttributes = tableAttributes;
        }

    }
}

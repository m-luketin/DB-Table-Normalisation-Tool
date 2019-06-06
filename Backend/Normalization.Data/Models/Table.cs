using System.Collections.Generic;

namespace Normalization.Data.Models
{
    public class Table : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TableAttribute> TableAttributes { get; set; }

        public Table()
        {
            
        }

        public Table(string name)
        {
            Name = name;
        }

        public Table
        (
            string name,
            ICollection<TableAttribute> tableAttributes
        )
        {
            Name = name;
            TableAttributes = tableAttributes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Models;
using Attribute = Normalization.Data.Models.Attribute;

namespace Normalization.Maps.Factory
{
    public static  class ModelFactory
    {
        public static IEntity CreateTable(string name)
        {
            return new Table(name);
        }

        public static IEntity CreateAttribute(string columnName)
        {
            return new Attribute(columnName);
        }

        public static IEntity CreateTableAttribute(Table table, Attribute attribute)
        {
            return new TableAttribute(table,attribute);
        }
    }
}

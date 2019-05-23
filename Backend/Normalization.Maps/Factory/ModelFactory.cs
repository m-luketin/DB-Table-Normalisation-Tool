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
        public static Table CreateTable(string name)
        {
            return new Table(name);
        }

        public static Attribute CreateAttribute(string columnName)
        {
            return new Attribute(columnName);
        }

        public static TableAttribute CreateTableAttribute(Table table, Attribute attribute)
        {
            return new TableAttribute(table,attribute);
        }

        public static TableAttributeCollection CreateTableAttributeCollection(Table table, Attribute attribute)
        {
            return new TableAttributeCollection();
        }
        public static AttributeCollection CreateAttributeCollection(List<Attribute> attributeList)
        {
            return new AttributeCollection();
        }

        public static FunctionalDependency CreateFunctionalDependency()
        {
            return new FunctionalDependency();
        }

        public static KeyGroup CreateKeyGroup()
        {
            return new KeyGroup();
        }
    }
}

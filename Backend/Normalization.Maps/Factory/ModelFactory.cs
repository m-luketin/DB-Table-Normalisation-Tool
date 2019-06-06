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

        public static IEntity CreateTable()
        {
            return new Table();
        }

        public static IEntity CreateAttribute(string columnName)
        {
            return new Attribute(columnName);
        }

        public static IEntity CreateAttribute()
        {
            return new Attribute();
        }

        public static IEntity CreateTableAttribute(IEntity table,IEntity attribute)
        {
            return new TableAttribute((Table)table,(Attribute)attribute);
        }

        public static IEntity CreateTableAttribute()
        {
            return new TableAttribute();
        }

        public static IEntity CreateTableAttributeCollection()
        {
            return new TableAttributeCollection();
        }

        public static IEntity CreateAttributeCollection()
        {
            return new AttributeCollection();
        }

        public static IEntity CreateFunctionalDependency()
        {
            return new FunctionalDependency();
        }

        public static IEntity CreateKeyGroup()
        {
            return new KeyGroup();
        }
    }
}

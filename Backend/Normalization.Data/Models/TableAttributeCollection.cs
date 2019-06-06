namespace Normalization.Data.Models
{
    public class TableAttributeCollection : IEntity
    {
        public int Id { get; set; }
        public AttributeCollection AttributeCollection { get; set; }
        public int AttributeCollectionId { get; set; }
        public TableAttribute TableAttribute { get; set; }
        public int TableAttributeId { get; set; }

        public TableAttributeCollection()
        {
            
        }

        public TableAttributeCollection
        (
            AttributeCollection attributeCollection,
            TableAttribute tableAttribute
        )
        {
            AttributeCollection = attributeCollection;
            TableAttribute = tableAttribute;
            AttributeCollectionId = attributeCollection.Id;
            TableAttributeId = tableAttribute.Id;
        }
    }
}

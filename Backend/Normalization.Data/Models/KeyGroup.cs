namespace Normalization.Data.Models
{
    public class KeyGroup : IEntity
    {
        public int Id { get; set; }
        public AttributeCollection AttributeCollection { get; set; }
        public int AttributeCollectionId { get; set; }

        public KeyGroup()
        {
            
        }

        public KeyGroup(AttributeCollection attributeCollection)
        {
            AttributeCollection = attributeCollection;
            AttributeCollectionId = attributeCollection.Id;
        }
    }
}

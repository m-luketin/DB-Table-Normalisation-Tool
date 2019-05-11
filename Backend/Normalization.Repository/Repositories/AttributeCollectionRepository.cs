using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;

namespace Normalization.Repository.Repositories
{
    public class AttributeCollectionRepository
    {
        private readonly AttributeCollectionContext _attributeCollectionContext;

        public AttributeCollectionRepository()
        {
            _attributeCollectionContext = new AttributeCollectionContext();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;

namespace Normalization.Repository.Repositories
{
    public class AttributeRepository
    {
        private readonly AttributeContext _attributeContext;

        public AttributeRepository()
        {
            _attributeContext = new AttributeContext();
        }
    }
}

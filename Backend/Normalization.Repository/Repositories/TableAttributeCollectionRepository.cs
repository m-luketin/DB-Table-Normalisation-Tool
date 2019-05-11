using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;

namespace Normalization.Repository.Repositories
{
    public class TableAttributeCollectionRepository
    {
        private readonly TableAttributeCollectionContext _tableAttributeCollectionContext;

        public TableAttributeCollectionRepository()
        {
            _tableAttributeCollectionContext = new TableAttributeCollectionContext();
        }
    }
}

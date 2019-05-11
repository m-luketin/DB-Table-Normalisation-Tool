using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;

namespace Normalization.Repository.Repositories
{
    public class TableAttributeRepository
    {
        private readonly TableAttributeContext _tableAttributeContext;
        public TableAttributeRepository()
        {
            _tableAttributeContext = new TableAttributeContext();
        }
    }
}

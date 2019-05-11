using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;

namespace Normalization.Repository.Repositories
{
    public class KeyGroupRepository
    {
        private readonly KeyGroupContext _keyGroupContext;

        public KeyGroupRepository()
        {
            _keyGroupContext = new KeyGroupContext();
        }
    }
}

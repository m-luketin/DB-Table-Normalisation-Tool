using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;
using Normalization.Repository.Interfaces;

namespace Normalization.Repository.Repositories
{
    public class DependencyElementRepository
    {
        private readonly DependencyElementContext _dependencyElementContext;

        public DependencyElementRepository()
        {
            _dependencyElementContext = new DependencyElementContext();
        }
    }
}

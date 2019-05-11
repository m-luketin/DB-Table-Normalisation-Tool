using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;

namespace Normalization.Repository.Repositories
{
    public class FunctionalDependencyRepository
    {
        private readonly FunctionalDependencyContext _functionalDependencyContext;

        public FunctionalDependencyRepository()
        {
            _functionalDependencyContext = new FunctionalDependencyContext();
        }
    }
}

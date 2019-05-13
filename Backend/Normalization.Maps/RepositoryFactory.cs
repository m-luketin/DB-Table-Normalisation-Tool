using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Normalization.Repository.Interfaces;
using Normalization.Repository.Repositories;

namespace Normalization.Maps.Factory
{
    public class RepositoryFactory
    {
        public IRepository CreateTableRepository()
        {
            return new TableRepository();
        }

        public IRepository CreateDependencyElementRepository()
        {
            return new DependencyElementRepository();
        }
    }
}

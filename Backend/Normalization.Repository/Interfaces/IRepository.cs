using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;
using Normalization.Data.Models;

namespace Normalization.Repository.Interfaces
{
    public interface IRepository
    {
        void Create(IEntity entity);
        void Delete(IEntity entity);
        void Delete(int id);
        void Edit(IEntity entity);

        IEntity GetById(int id);

    }
}

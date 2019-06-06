using System.Linq;
using Normalization.Data.Models;

namespace Normalization.Repository.Interfaces
{
    public interface IRepository
    {
        IQueryable Read();
        void Create(ref IEntity entity);
        void Delete(IEntity entity);
        void Delete(int id);
        IEntity Edit(IEntity entity);
        IEntity GetById(int id);
    }
}

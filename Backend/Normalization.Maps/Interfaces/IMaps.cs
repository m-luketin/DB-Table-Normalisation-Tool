using System.Collections.Generic;
using Normalization.ViewModel;

namespace Normalization.Maps
{
    public interface IMaps
    {
        IViewModel Create(IViewModel item);
        IViewModel ReadFromId(int id);
        IViewModel Update(IViewModel item);
        ICollection<IViewModel> Read();
        void Delete(int id);
    }
}

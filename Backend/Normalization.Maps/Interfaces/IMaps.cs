using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Repository.Interfaces;
using Normalization.ViewModel;

namespace Normalization.Maps
{
    public interface IMaps
    {
        IViewModel Create(IViewModel item);
        IViewModel Update(IViewModel item);
        IViewModel ReadFromId(int id);
        ICollection<IViewModel> Read();
        void Delete(int id);
    }
}

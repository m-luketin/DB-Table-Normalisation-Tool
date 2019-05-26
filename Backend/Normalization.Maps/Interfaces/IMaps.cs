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
        IViewModel ReadFromId(int id);
        IViewModel Update(IViewModel item);
        ICollection<IViewModel> Read();
        void Delete(int id);
    }
}

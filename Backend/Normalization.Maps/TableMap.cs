using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.ViewModel;

namespace Normalization.Maps
{
    public class TableMap :IMaps
    {
        public IViewModel Create(IViewModel item)
        {
            throw new NotImplementedException();
        }

        public IViewModel Update(IViewModel item)
        {
            throw new NotImplementedException();
        }

        public IViewModel ReadFromId(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<IViewModel> Read()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

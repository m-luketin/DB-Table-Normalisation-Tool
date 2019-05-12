using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Models;
using Normalization.Maps.Factory;
using Normalization.Repository.Interfaces;
using Normalization.ViewModel;

namespace Normalization.Maps
{
    public class TableMaps : IMaps
    {
        private Table ViewTableToTable(IViewModel tableView)
        {
           
        }
        public IViewModel Create(IViewModel item)
        {
            var tableViewModel = (TableViewModel) item;
            var tableRepository = RepositoryFactory.CreateTableRepository();
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

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
    public class TableMap :IMaps
    {
        public IRepository TableRepository { get; set; }
        public IRepository AttributesRepository { get; set; }
        public IRepository DependencyElementRepository { get; set; }
        public IRepository FunctionalDependencyRepository { get; set; }
        public IRepository KeyGroupRepository { get; set; }
        public IRepository TableAttributeCollectionRepository { get; set; }
        public IRepository AttributeCollectionRepository { get; set; }
        public IRepository TableAttributeRepository { get; set; }

        public TableMap()
        {
            TableRepository = RepositoryFactory.CreateTableRepository();
            AttributesRepository = RepositoryFactory.CreateAttributeRepository();
            DependencyElementRepository = RepositoryFactory.CreateDependencyElementRepository();
            FunctionalDependencyRepository = RepositoryFactory.CreateFunctionalDependencyRepository();
            KeyGroupRepository = RepositoryFactory.CreateKeyGroupRepository();
            TableAttributeCollectionRepository = RepositoryFactory.CreateTableAttributeCollectionRepository();
            AttributeCollectionRepository = RepositoryFactory.CreateAttributeCollectionRepository();
            TableAttributeRepository = RepositoryFactory.CreateTableAttributeRepository();
        }
        public IViewModel Create(IViewModel item)
        {
            var viewItem = (TableViewModel) item;
            var tableModel = ModelFactory.CreateTable(viewItem.Name);
            var attributeModelList = new List<IEntity>();
            foreach (var viewItemAttribute in viewItem.Attributes)
            {
                var attributeModel = ModelFactory.CreateAttribute(viewItemAttribute);
                AttributesRepository.Create(attributeModel);
                attributeModelList.Add(attributeModel);
            }
            TableRepository.Create(tableModel);
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

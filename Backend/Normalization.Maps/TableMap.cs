using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Models;
using Normalization.Maps.Factory;
using Normalization.Repository.Interfaces;
using Normalization.Repository.Repositories;
using Normalization.ViewModel;

namespace Normalization.Maps
{
    public class TableMap :IMaps
    {
        public IViewModel Create(IViewModel item)
        {
            var viewItem = (TableViewModel) item;
            var attributeList = new List<IEntity>();
            var tableAttributeList = new List<IEntity>();
            var tableAttributesFrom = new List<IEntity>();
            var tableAttributesTo = new List<IEntity>();
            var tableModel = ModelFactory.CreateTable(viewItem.Name);
            RepositoryFactory.CreateTableRepository().Create(ref tableModel);

            foreach (var viewItemAttribute in viewItem.Attributes)
            {
                var attributeModel = ModelFactory.CreateAttribute(viewItemAttribute);
                RepositoryFactory.CreateAttributeRepository().Create(ref attributeModel);
                var tableAttributeModel = ModelFactory.CreateTableAttribute(tableModel,attributeModel);
                RepositoryFactory.CreateTableAttributeRepository().Create(ref tableAttributeModel);
                attributeList.Add(attributeModel);
            }

            foreach (var dependencyViews in viewItem.Dependencies)
            {
                tableAttributesFrom.AddRange(dependencyViews.From.Select(attributeCollection => RepositoryFactory.CreateTableAttributeRepository().GetByName(attributeCollection)));
                tableAttributesTo.Add(RepositoryFactory.CreateTableAttributeRepository().GetByName(dependencyViews.To));
            }

            foreach (var tableAttribute in tableAttributesFrom)
            {
                var functionalDependency = ModelFactory.CreateFunctionalDependency();
                var tableAttributeModel = ModelFactory.CreateTableAttributeCollection();
                functionalDependency = tableAttribute;
                tableAttributeModel = tableAttribute;
                RepositoryFactory.CreateTableAttributeCollectionRepository().Create(ref tableAttributeModel);
                RepositoryFactory.CreateAttributeCollectionRepository().Create(ref tableAttributeModel);
                RepositoryFactory.CreateFunctionalDependencyRepository().Create(ref functionalDependency);
                RepositoryFactory.CreateDependencyElementRepository()
                    .CreateWithAttributeCollection(true, tableAttributeModel,functionalDependency);

            }
            foreach (var tableAttribute in tableAttributesTo)
            {
                var functionalDependency = ModelFactory.CreateFunctionalDependency();
                var tableAttributeModel = ModelFactory.CreateTableAttributeCollection();
                functionalDependency = tableAttribute;
                tableAttributeModel = tableAttribute;
                RepositoryFactory.CreateTableAttributeCollectionRepository().Create(ref tableAttributeModel);
                RepositoryFactory.CreateFunctionalDependencyRepository().Create(ref functionalDependency);
                RepositoryFactory.CreateAttributeCollectionRepository().Create(ref tableAttributeModel);
                RepositoryFactory.CreateDependencyElementRepository()
                    .CreateWithAttributeCollection(false, tableAttributeModel, functionalDependency);
            }

            foreach (var keyGroupsView in viewItem.Keys)
            {
                var tableAttributeCollectionKeyGroupList = keyGroupsView.Select(keyGroupString => RepositoryFactory.CreateTableAttributeRepository().GetByName(keyGroupString)).ToList();
                foreach (var tableAttributeCollection in tableAttributeCollectionKeyGroupList)
                {
                    var tableAttributeCollectionModel = ModelFactory.CreateTableAttributeCollection();
                    tableAttributeCollectionModel = tableAttributeCollection;
                    RepositoryFactory.CreateAttributeCollectionRepository().Create(ref tableAttributeCollectionModel);
                    RepositoryFactory.CreateKeyGroupRepository().Create(ref tableAttributeCollectionModel);
                }
            }

            return viewItem;

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
            var tableViewList = new List<IViewModel>();
            var tableList = RepositoryFactory.CreateTableRepository().Read();
            foreach (var table in tableList)
            {
                var tableAttributes = table.Cast<Table>().Where(tab => tab.TableAttributes.All(tableAttr => tableAttr.Id == tab.Id));

                var attributes = tableAttributes.Cast<TableAttribute>().Where(tableAttribute =>
                    tableAttribute.Attribute.TableAttributes.All(attr => attr.Id == tableAttribute.AttributeId));

                var tableAttributeCollections = tableAttributes.Cast<TableAttribute>().Where(tableAttr =>
                    tableAttr.TableAttributeCollection.All(tableAttrCol =>
                        tableAttrCol.TableAttributeId == tableAttr.Id));

                var attributeCollections = tableAttributeCollections.Cast<AttributeCollection>().Where(attrCol =>
                    attrCol.TableAttributeCollections.All(tableAttrCol => tableAttrCol.Id == attrCol.Id));

                var keyGroups = attributeCollections.Cast<AttributeCollection>().Where(attrCol =>
                    attrCol.KeyGroup.All(keyGrp => keyGrp.AttributeCollection.Id == attrCol.Id));

                var dependencyFrom = attributeCollections.Cast<DependencyElement>().Where(dependElem => dependElem.AttributeCollection.Id == dependElem.Id && dependElem.IsLeft);

                var dependencyTo = attributeCollections.Cast<DependencyElement>().Where(dependElem => dependElem.AttributeCollection.Id == dependElem.Id && !dependElem.IsLeft);
                var functionalDependencies = dependencyFrom.Cast<FunctionalDependency>().Where(funcDepend =>
                    funcDepend.DependencyElements.All(dependElem => dependElem.Id == funcDepend.Id));
                var tableInMemory = (Table)table;

                var dependencyToString =dependencyTo.Select(dependTo =>
                    dependTo.AttributeCollection.TableAttributeCollections
                        .Select(tableAttr => tableAttr.TableAttribute.Attribute.ColumnName).ToString()).ToList()[0];
                var dependencies = new List<DependencyViewModel>();
                dependencies.AddRange(functionalDependencies
                                        .Select(funcDepend =>
                                            new DependencyViewModel(
                                                funcDepend.Id,
                                                dependencyFrom.Select(dependFrom =>
                                                    dependFrom.AttributeCollection.TableAttributeCollections
                                                        .Select(tableAttr => tableAttr.TableAttribute.Attribute.ColumnName).ToString()).ToList(),
                                                dependencyToString)));
                var keys = new List<ICollection<string>>();
                keys.AddRange(tableAttributeCollections.Select(tableAttr => keyGroups.Select(keyGrp => keyGrp.TableAttributeCollections.Where(attrTable => attrTable.TableAttribute.Id == tableAttr.Id).Select(attrTable=> attrTable.TableAttribute.Attribute.ColumnName).ToString()).ToList()));
                tableViewList.Add(new TableViewModel
                {
                    Name = tableInMemory.Name,
                    Attributes = new List<string>(attributes.Select(attr => attr.Attribute.ColumnName)),
                    Dependencies = dependencies,
                    Keys = keys
                });
            }

            return tableViewList;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

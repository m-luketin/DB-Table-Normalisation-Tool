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
            RepositoryFactory.CreateTableRepository().Create(tableModel);

            foreach (var viewItemAttribute in viewItem.Attributes)
            {
                var attributeModel = ModelFactory.CreateAttribute(viewItemAttribute);
                RepositoryFactory.CreateAttributeRepository().Create(attributeModel);
                var tableAttributeModel = ModelFactory.CreateTableAttribute(tableModel, attributeModel);
                RepositoryFactory.CreateTableAttributeRepository().Create(tableAttributeModel);
                attributeList.Add(attributeModel);
            }

            foreach (var dependencyViews in viewItem.Dependencies)
            {
                tableAttributesFrom.AddRange(dependencyViews.From.Select(attributeCollection => RepositoryFactory.CreateTableAttributeRepository().GetByName(attributeCollection)));
                tableAttributesTo.Add(RepositoryFactory.CreateTableAttributeRepository().GetByName(dependencyViews.To));
            }

            foreach (var tableAttribute in tableAttributesFrom)
            {
                RepositoryFactory.CreateTableAttributeCollectionRepository().Create(tableAttribute);
                var attributeCollectionsFrom = RepositoryFactory.CreateAttributeCollectionRepository().Create(tableAttribute);
                var functionalDependency = RepositoryFactory.CreateFunctionalDependencyRepository().Create(ModelFactory.CreateFunctionalDependency());
                RepositoryFactory.CreateDependencyElementRepository()
                    .CreateWithAttributeCollection(true, attributeCollectionsFrom,functionalDependency);

            }
            foreach (var tableAttribute in tableAttributesTo)
            {
                RepositoryFactory.CreateTableAttributeCollectionRepository().Create(tableAttribute);
                var functionalDependency = RepositoryFactory.CreateFunctionalDependencyRepository().Create(ModelFactory.CreateFunctionalDependency());
                var attributeCollectionsTo = RepositoryFactory.CreateAttributeCollectionRepository().Create(tableAttribute);
                RepositoryFactory.CreateDependencyElementRepository()
                    .CreateWithAttributeCollection(false, attributeCollectionsTo,functionalDependency);
            }

            foreach (var keyGroupsView in viewItem.Keys)
            {
                var tableAttributeCollectionKeyGroupList = keyGroupsView.Select(keyGroupString => RepositoryFactory.CreateTableAttributeRepository().GetByName(keyGroupString)).ToList();
                foreach (var tableAttributeCollection in tableAttributeCollectionKeyGroupList)
                {
                    var attributeCollectionKeyGroup = RepositoryFactory.CreateAttributeCollectionRepository()
                        .Create(tableAttributeCollection);
                    RepositoryFactory.CreateKeyGroupRepository().Create(attributeCollectionKeyGroup);
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
                var tableAttributes = table.Cast<Table>().Where(tab => tab.TableAttributes.All(tableAttr => tableAttr.PrimaryId == tab.PrimaryId));

                var attributes = tableAttributes.Cast<TableAttribute>().Where(tableAttribute =>
                    tableAttribute.Attribute.TableAttributes.All(attr => attr.PrimaryId == tableAttribute.AttributeId));

                var tableAttributeCollections = tableAttributes.Cast<TableAttribute>().Where(tableAttr =>
                    tableAttr.TableAttributeCollection.All(tableAttrCol =>
                        tableAttrCol.TableAttributeId == tableAttr.PrimaryId));

                var attributeCollections = tableAttributeCollections.Cast<AttributeCollection>().Where(attrCol =>
                    attrCol.TableAttributeCollections.All(tableAttrCol => tableAttrCol.PrimaryId == attrCol.PrimaryId));

                var keyGroups = attributeCollections.Cast<AttributeCollection>().Where(attrCol =>
                    attrCol.KeyGroup.All(keyGrp => keyGrp.AttributeCollection.PrimaryId == attrCol.PrimaryId));

                var dependencyFrom = attributeCollections.Cast<DependencyElement>().Where(dependElem => dependElem.AttributeCollection.PrimaryId == dependElem.PrimaryId && dependElem.IsLeft);

                var dependencyTo = attributeCollections.Cast<DependencyElement>().Where(dependElem => dependElem.AttributeCollection.PrimaryId == dependElem.PrimaryId && !dependElem.IsLeft);
                var functionalDependencies = dependencyFrom.Cast<FunctionalDependency>().Where(funcDepend =>
                    funcDepend.DependencyElements.All(dependElem => dependElem.PrimaryId == funcDepend.PrimaryId));
                var tableInMemory = (Table)table;

                var dependencyToString =dependencyTo.Select(dependTo =>
                    dependTo.AttributeCollection.TableAttributeCollections
                        .Select(tableAttr => tableAttr.TableAttribute.Attribute.ColumnName).ToString()).ToList()[0];
                var dependencies = new List<DependencyViewModel>();
                dependencies.AddRange(functionalDependencies
                                        .Select(funcDepend =>
                                            new DependencyViewModel(
                                                funcDepend.PrimaryId,
                                                dependencyFrom.Select(dependFrom =>
                                                    dependFrom.AttributeCollection.TableAttributeCollections
                                                        .Select(tableAttr => tableAttr.TableAttribute.Attribute.ColumnName).ToString()).ToList(),
                                                dependencyToString)));
                var keys = new List<ICollection<string>>();
                keys.AddRange(tableAttributeCollections.Select(tableAttr => keyGroups.Select(keyGrp => keyGrp.TableAttributeCollections.Where(attrTable => attrTable.TableAttribute.PrimaryId == tableAttr.PrimaryId).Select(attrTable=> attrTable.TableAttribute.Attribute.ColumnName).ToString()).ToList()));
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

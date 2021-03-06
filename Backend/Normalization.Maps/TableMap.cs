﻿using System;
using System.Collections.Generic;
using System.Linq;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Maps.Factory;
using Normalization.Repository.Repositories;
using Normalization.ViewModel;

namespace Normalization.Maps
{
    public class TableMap :IMaps
    {
        public IViewModel Create(IViewModel item)
        {
            var viewItem = (TableViewModel) item;
            List<IEntity> attributeList;
            attributeList = new List<IEntity>();
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
                var functionalDependency = ModelFactory.CreateFunctionalDependency();
                RepositoryFactory.CreateFunctionalDependencyRepository().Create(ref functionalDependency);
                var tableAttributesFrom = new List<IEntity>();
                var tableAttributesTo = new List<IEntity>();
                tableAttributesFrom.AddRange(dependencyViews.From.Select(attributeCollection => RepositoryFactory.CreateTableAttributeRepository().GetByNameAndTableId(attributeCollection,tableModel.Id)));
                tableAttributesTo.Add(RepositoryFactory.CreateTableAttributeRepository().GetByNameAndTableId(dependencyViews.To,tableModel.Id));
                var attributeCollectionModel = ModelFactory.CreateAttributeCollection();
                foreach (var entity in tableAttributesFrom)
                {
                    RepositoryFactory.CreateAttributeCollectionRepository().Create(ref attributeCollectionModel);
                    var tableAttributeCollectionFrom = (TableAttributeCollection)ModelFactory.CreateTableAttributeCollection();
                    tableAttributeCollectionFrom.TableAttribute = (TableAttribute)entity;
                    tableAttributeCollectionFrom.AttributeCollection = (AttributeCollection) attributeCollectionModel;
                    var tableAttributeCollectionFormIEntity = (IEntity) tableAttributeCollectionFrom;
                    RepositoryFactory.CreateTableAttributeCollectionRepository().Create(ref tableAttributeCollectionFormIEntity);
                    RepositoryFactory.CreateDependencyElementRepository()
                    .CreateWithAttributeCollection(true,attributeCollectionModel, functionalDependency);
                }

                foreach (var entity in tableAttributesTo)
                {
                    RepositoryFactory.CreateAttributeCollectionRepository().Create(ref attributeCollectionModel);
                    var tableAttributeCollectionFrom = (TableAttributeCollection)ModelFactory.CreateTableAttributeCollection();
                    tableAttributeCollectionFrom.TableAttribute = (TableAttribute)entity;
                    tableAttributeCollectionFrom.AttributeCollection = (AttributeCollection)attributeCollectionModel;
                    var tableAttributeCollectionFormIEntity = (IEntity)tableAttributeCollectionFrom;
                    RepositoryFactory.CreateTableAttributeCollectionRepository().Create(ref tableAttributeCollectionFormIEntity);
                    RepositoryFactory.CreateDependencyElementRepository()
                        .CreateWithAttributeCollection(false, attributeCollectionModel, functionalDependency);
                }

            }

            foreach (var keyGroupsView in viewItem.Keys)
            {
                var tableAttributeList = keyGroupsView.Select(keyGroupString => RepositoryFactory.CreateTableAttributeRepository().GetByNameAndTableId(keyGroupString,tableModel.Id)).ToList();

                var keyGroupModel = (KeyGroup)ModelFactory.CreateKeyGroup();
                var attributeCollectionModel = ModelFactory.CreateAttributeCollection();
                RepositoryFactory.CreateAttributeCollectionRepository().Create(ref attributeCollectionModel);
                keyGroupModel.AttributeCollection = (AttributeCollection)attributeCollectionModel;
                var keyGroupIEntity = (IEntity) keyGroupModel;
                RepositoryFactory.CreateKeyGroupRepository().Create(ref keyGroupIEntity);

                foreach (var tableAttribute in tableAttributeList)
                {
                    var tableAttributeCollectionModel = (TableAttributeCollection)ModelFactory.CreateTableAttributeCollection();

                    tableAttributeCollectionModel.AttributeCollection = (AttributeCollection)attributeCollectionModel;
                    tableAttributeCollectionModel.TableAttribute = ((TableAttribute) tableAttribute);

                    var tableAttributeCollectionModelIEntity = (IEntity) tableAttributeCollectionModel;
                    RepositoryFactory.CreateTableAttributeCollectionRepository().Create(ref tableAttributeCollectionModelIEntity);
                }
            }
            return ReadFromId(tableModel.Id);
        }

        public IViewModel ReadFromId(int id)
        {
            var _contextToDatabase = new ConfigurationContext();
            var tableEntity = _contextToDatabase.Tables.Find(id);
            if (tableEntity == null) throw new Exception("Table not exists.");
            var tableAttributeList = _contextToDatabase.TableAttributes
                   .Select(tableAttr => tableAttr)
                   .Where(tableAttr => tableAttr.TableId == tableEntity.Id);

            var attributeList = _contextToDatabase.Attributes
                .Select(attr => attr)
                .Where(attr => tableAttributeList.Any(tableAttr => tableAttr.AttributeId == attr.Id));

            var tableAttributeCollectionList = _contextToDatabase.TableAttributeCollections
                .Select(tableAttrCol => tableAttrCol)
                .Where(tableAttrCol => tableAttributeList.Any(tableAttr => tableAttr.Id == tableAttrCol.TableAttributeId));

            var attributeCollectionList = _contextToDatabase.AttributeCollections
                .Select(attrCol => attrCol)
                .Where(attrCol =>
                    tableAttributeCollectionList.Any(tableAttrCol =>
                        tableAttrCol.AttributeCollectionId == attrCol.Id)).ToList();

            var keyGroupList = _contextToDatabase.KeyGroups
                .Select(keyGroup => keyGroup)
                .Where(keyGroup =>
                    attributeCollectionList.Any(attrCol => keyGroup.AttributeCollectionId == attrCol.Id)).ToList();

            var dependencyElementList = _contextToDatabase.DependencyElements
                .Select(dependElem => dependElem)
                .Where(dependElem =>
                    attributeCollectionList.Any(attrCol => dependElem.AttributeCollectionId == attrCol.Id));

            var functionalDependencyList = _contextToDatabase.FunctionalDependencies
                .Select(funcDepend => funcDepend)
                .Where(funcDepend =>
                    dependencyElementList.Any(dependElem => dependElem.FunctionalDependencyId == funcDepend.Id))
                .Select(funcDepend => funcDepend.Id).ToList();

            Func<IQueryable<TableAttribute>, IQueryable<AttributeCollection>, IQueryable<TableAttribute>>
                ResolveTableAttributesOnTableAttributeCollection =
                    (tableAttribute, attributeCollection) =>
                    {
                        return tableAttribute.Where(tableAttr =>
                            tableAttr.TableAttributeCollection.Any(tableAttrCol =>
                                attributeCollection.Any(_ => _.Id == tableAttrCol.AttributeCollectionId)));
                    };
            var dependencies = new List<DependencyViewModel>();
            foreach (var functionalDependId in functionalDependencyList)
            {

                var fromDependencyElements = dependencyElementList.Where(dependElem =>
                    dependElem.IsLeft && dependElem.FunctionalDependencyId == functionalDependId);
                var toDependencyElements = dependencyElementList.Where(dependElem =>
                    !dependElem.IsLeft && dependElem.FunctionalDependencyId == functionalDependId);

                var fromAttributeCollections = fromDependencyElements.Select(dependElem =>
                    dependElem.AttributeCollection);
                var toAttributeCollections = toDependencyElements.Select(dependElem =>
                    dependElem.AttributeCollection);
                var fromTableAttributes = ResolveTableAttributesOnTableAttributeCollection(tableAttributeList, fromAttributeCollections);
                var toTableAttributes =
                    ResolveTableAttributesOnTableAttributeCollection(tableAttributeList, toAttributeCollections);
                dependencies.Add(new DependencyViewModel(
                    functionalDependId,
                    fromTableAttributes.Select(_ => _.Attribute.ColumnName).ToList(),
                    toTableAttributes.Select(_ => _.Attribute.ColumnName).ToList()[0]));
            }

            var keyGroupListView = new List<ICollection<string>>();
                foreach (var keyGroup in keyGroupList)
                {
                    var keyGroupAttributeCollection =
                        attributeCollectionList.Where(attrCol => attrCol.Id == keyGroup.AttributeCollectionId).AsQueryable();
                    var keyGroupTableAttributes =
                        ResolveTableAttributesOnTableAttributeCollection(tableAttributeList, keyGroupAttributeCollection);
                    keyGroupListView.Add(keyGroupTableAttributes.Select(keyGrp => keyGrp.Attribute.ColumnName).ToList());
                }

                return new TableViewModel
                {
                    Name = tableEntity.Name,
                    Attributes = attributeList.Select(_ => _.ColumnName).ToList(),
                    Dependencies = dependencies,
                    Keys = keyGroupListView,
                    PrimaryId = tableEntity.Id
                };
        }

        public IViewModel Update(IViewModel item)
        {
            if (item.PrimaryId == null) throw new Exception("Table not exists");
            Delete((int)item.PrimaryId);
            return Create(item);
        }

        public ICollection<IViewModel> Read()
        {
            var tableViewList = new List<IViewModel>();
            var tablesModelList = new List<Table>();
            var _contextToDatabase = new ConfigurationContext();
            tablesModelList.AddRange(_contextToDatabase.Tables.Cast<Table>().Select(table => table).ToList());
            foreach (var tableEntity in tablesModelList)
            {
               
                tableViewList.Add(ReadFromId(tableEntity.Id));
            }
            return tableViewList;
        }

        public void Delete(int id)
        {
            ((AttributeCollectionRepository)RepositoryFactory.CreateAttributeCollectionRepository()).DeleteByTable(id);
            RepositoryFactory.CreateTableRepository().Delete(id);
        }
    }
}

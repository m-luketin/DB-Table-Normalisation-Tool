using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Interfaces;
using Attribute = Normalization.Data.Models.Attribute;

namespace Normalization.Repository.Repositories
{
    public class TableAttributeRepository : IRepository
    {
        private readonly ConfigurationContext _tableAttributeContext;
        public TableAttributeRepository()
        {
            _tableAttributeContext = new ConfigurationContext();
        }
        public IQueryable Read()
        {
            return _tableAttributeContext.TableAttributes;
        }
        public void Create(ref IEntity entity)
        {
            var tableAttributeNew = (TableAttribute) entity;
            var table = _tableAttributeContext.Tables.Find(tableAttributeNew.Table.Id);
            var attribute = _tableAttributeContext.Attributes.Find(tableAttributeNew.Attribute.Id);
            var tableAttribute =_tableAttributeContext.TableAttributes.Add(new TableAttribute(table,attribute));
            _tableAttributeContext.SaveChanges();
            entity = tableAttribute.Entity;
        }

        public void Delete(IEntity entity)
        {
            _tableAttributeContext.TableAttributes.Remove((TableAttribute)entity);
            _tableAttributeContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Delete(GetById(id));
            _tableAttributeContext.SaveChanges();
        }

        public IEntity Edit(IEntity entity)
        {
            var tableAttributeNew = (TableAttribute) entity;
            var tableAttribute = (TableAttribute) entity;
            tableAttribute.Attribute = tableAttributeNew.Attribute;
            tableAttribute.Table = tableAttributeNew.Table;
            tableAttribute.TableAttributeCollection = tableAttributeNew.TableAttributeCollection;
            _tableAttributeContext.TableAttributes.Update(tableAttribute);
            _tableAttributeContext.SaveChanges();
            return tableAttribute;
        }

        public IEntity GetById(int id)
        {
            return _tableAttributeContext.TableAttributes.Find(id);
        }

        public IEntity GetByName(string nameAttribute)
        {
            return _tableAttributeContext.TableAttributes.FirstOrDefault(tableAttr => tableAttr.Attribute.ColumnName == nameAttribute);
        }
    }
}

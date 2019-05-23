using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Contexts;
using Normalization.Data.Models;
using Normalization.Repository.Interfaces;

namespace Normalization.Repository.Repositories
{
    public class TableAttributeRepository : IRepository
    {
        private readonly TableAttributeContext _tableAttributeContext;
        public TableAttributeRepository()
        {
            _tableAttributeContext = new TableAttributeContext();
        }
        public ICollection<IQueryable> Read()
        {
            return (ICollection<IQueryable>)_tableAttributeContext.TableAttributes.ToList();
        }
        public IEntity Create(IEntity entity)
        {
            var tableAttribute = (TableAttribute) entity;
            _tableAttributeContext.TableAttributes.Add(tableAttribute);
            _tableAttributeContext.SaveChanges();
            return tableAttribute;
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
            return (IEntity)_tableAttributeContext.TableAttributes.Where(tableAttr => tableAttr.Attribute.ColumnName == nameAttribute);
        }
    }
}

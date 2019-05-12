using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Normalization.Data.Models;

namespace Normalization.Maps.Factory
{
    public class ModelFactory
    {
        public IEntity CreateTable()
        {
            return new Table();
        }

        public IEntity CreateAttribute()
        {
            return new Normalization.Data.Models.Attribute();
        }
    }
}

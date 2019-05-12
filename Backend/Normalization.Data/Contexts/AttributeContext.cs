using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Normalization.Data.Models;

namespace Normalization.Data.Contexts
{
    public class AttributeContext : BaseContext
    {
        public DbSet<Models.Attribute> Attributes { get; set; }
    }
    
}

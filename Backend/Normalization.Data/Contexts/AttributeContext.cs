using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Normalization.Data.Models;
using Attribute = Normalization.Data.Models.Attribute;

namespace Normalization.Data.Contexts
{
    public class AttributeContext : DbContext
    {
        public DbSet<Attribute> Attributes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["NormalizationContext"].ConnectionString);
        }
    }
}

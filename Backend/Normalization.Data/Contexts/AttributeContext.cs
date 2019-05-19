using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Normalization.Data.Models;
using Attribute = Normalization.Data.Models.Attribute;

namespace Normalization.Data.Contexts
{
    public class AttributeContext : BaseContext
    {
        public DbSet<Attribute> Attributes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Attribute>().HasKey(attribute => attribute.PrimaryId);
        }
    }
    
}

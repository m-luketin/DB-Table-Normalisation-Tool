using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Normalization.Data.Models;

namespace Normalization.Data.Contexts
{
    public class AttributeCollectionContext : BaseContext
    {
        public DbSet<AttributeCollection> AttributeCollections { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AttributeCollection>().HasKey(attributeCollection => attributeCollection.PrimaryId);
        }
    }
}

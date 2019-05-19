using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Normalization.Data.Models;

namespace Normalization.Data.Contexts
{
    public class TableAttributeCollectionContext : BaseContext
    {
        public DbSet<TableAttributeCollection> TableAttributeCollections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TableAttributeCollection>()
                .HasKey(tableAttributeCollection => tableAttributeCollection.PrimaryId);

            modelBuilder.Entity<TableAttributeCollection>()
                .HasOne(tableAttributeCollection => tableAttributeCollection.TableAttribute)
                .WithMany(tableAttribute => tableAttribute.TableAttributeCollection)
                .HasForeignKey(tableAttributeCollection => tableAttributeCollection.TableAttributeId);
            modelBuilder.Entity<TableAttributeCollection>()
                .HasOne(tableAttributeCollection => tableAttributeCollection.AttributeCollection)
                .WithMany(attributeCollection => attributeCollection.TableAttributeCollections)
                .HasForeignKey(tableAttributeCollection => tableAttributeCollection.AttributeCollectionId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Normalization.Data.Models;

namespace Normalization.Data.Contexts
{
    public class TableAttributeContext : BaseContext
    {
        public DbSet<TableAttribute> TableAttributes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TableAttribute>()
                .HasOne(tableAttribute => tableAttribute.Attribute)
                .WithMany(table => table.TableAttributes)
                .HasForeignKey(tableAttribute => tableAttribute.TableId);

            modelBuilder.Entity<TableAttribute>()
                .HasOne(tableAttribute => tableAttribute.Table)
                .WithMany(table => table.TableAttributes)
                .HasForeignKey(tableAttribute => tableAttribute.AttributeId);
        }
    }
}

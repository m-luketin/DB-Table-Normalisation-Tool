using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Normalization.Data.Models;

namespace Normalization.Data.Contexts
{
    public class ConfigurationContext : DbContext
    {
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<DependencyElement> DependencyElements { get; set; }
        public DbSet<AttributeCollection> AttributeCollections { get; set; }
        public DbSet<FunctionalDependency> FunctionalDependencies { get; set; }
        public DbSet<KeyGroup> KeyGroups { get; set; }
        public DbSet<TableAttributeCollection> TableAttributeCollections { get; set; }
        public DbSet<TableAttribute> TableAttributes { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=Normalization;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["NormalizationContext"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attribute>().HasKey(attribute => attribute.PrimaryId);
            modelBuilder.Entity<AttributeCollection>().HasKey(attributeCollection => attributeCollection.PrimaryId);
            modelBuilder.Entity<DependencyElement>().HasKey(dependencyElement => dependencyElement.PrimaryId);
            modelBuilder.Entity<FunctionalDependency>().HasKey(functionalDependency => functionalDependency.PrimaryId);
            modelBuilder.Entity<KeyGroup>().HasKey(keyGroup => keyGroup.PrimaryId);
            modelBuilder.Entity<TableAttributeCollection>().HasKey(tableAttributeCollection => tableAttributeCollection.PrimaryId);
            modelBuilder.Entity<TableAttribute>().HasKey(tableAttribute => tableAttribute.PrimaryId);
            modelBuilder.Entity<Table>().HasKey((table => table.PrimaryId));

            modelBuilder.Entity<TableAttributeCollection>()
                .HasOne(tableAttributeCollection => tableAttributeCollection.TableAttribute)
                .WithMany(tableAttribute => tableAttribute.TableAttributeCollection)
                .HasForeignKey(tableAttributeCollection => tableAttributeCollection.TableAttributeId);
            modelBuilder.Entity<TableAttributeCollection>()
                .HasOne(tableAttributeCollection => tableAttributeCollection.AttributeCollection)
                .WithMany(attributeCollection => attributeCollection.TableAttributeCollections)
                .HasForeignKey(tableAttributeCollection => tableAttributeCollection.AttributeCollectionId);


            modelBuilder.Entity<TableAttribute>()
                .HasOne(tableAttribute => tableAttribute.Attribute)
                .WithMany(table => table.TableAttributes)
                .HasForeignKey(tableAttribute => tableAttribute.TableId);
            modelBuilder.Entity<TableAttribute>()
                .HasOne(tableAttribute => tableAttribute.Table)
                .WithMany(table => table.TableAttributes)
                .HasForeignKey(tableAttribute => tableAttribute.AttributeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

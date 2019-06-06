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
            modelBuilder.Entity<Attribute>()
                .HasMany(attr => attr.TableAttributes)
                .WithOne(tableAttr => tableAttr.Attribute)
                .HasForeignKey(tableAttr => tableAttr.AttributeId);

            modelBuilder.Entity<Table>()
                .HasMany(table => table.TableAttributes)
                .WithOne(tableAttr => tableAttr.Table)
                .HasForeignKey(tableAttr => tableAttr.TableId);
                
            modelBuilder.Entity<TableAttribute>()
                .HasOne(tableAttr => tableAttr.Attribute)
                .WithMany(attr => attr.TableAttributes)
                .HasForeignKey(tableAttr => tableAttr.AttributeId);
            modelBuilder.Entity<TableAttribute>()
                .HasOne(tableAttr => tableAttr.Table)
                .WithMany(table => table.TableAttributes)
                .HasForeignKey(tableAttr => tableAttr.TableId);
            modelBuilder.Entity<TableAttribute>()
                .HasMany(tableAttr => tableAttr.TableAttributeCollection)
                .WithOne(tableAttrCol => tableAttrCol.TableAttribute)
                .HasForeignKey(tableAttrCol => tableAttrCol.TableAttributeId);

            modelBuilder.Entity<TableAttributeCollection>()
                .HasOne(tableAttributeCollection => tableAttributeCollection.TableAttribute)
                .WithMany(tableAttribute => tableAttribute.TableAttributeCollection)
                .HasForeignKey(tableAttributeCollection => tableAttributeCollection.TableAttributeId);
            modelBuilder.Entity<TableAttributeCollection>()
                .HasOne(tableAttributeCollection => tableAttributeCollection.AttributeCollection)
                .WithMany(attributeCollection => attributeCollection.TableAttributeCollections)
                .HasForeignKey(tableAttributeCollection => tableAttributeCollection.AttributeCollectionId);

            modelBuilder.Entity<AttributeCollection>()
                .HasMany(attrCol => attrCol.TableAttributeCollections)
                .WithOne(tableAttrCol => tableAttrCol.AttributeCollection)
                .HasForeignKey(tableAttrCol => tableAttrCol.AttributeCollectionId);
            modelBuilder.Entity<AttributeCollection>()
                .HasMany(attrCol => attrCol.KeyGroup)
                .WithOne(keyGroup => keyGroup.AttributeCollection)
                .HasForeignKey(keyGroup => keyGroup.AttributeCollectionId);
            modelBuilder.Entity<AttributeCollection>()
                .HasMany(attrCol => attrCol.DependencyElements)
                .WithOne(funcDepend => funcDepend.AttributeCollection)
                .HasForeignKey(funcDepend => funcDepend.AttributeCollectionId);

            modelBuilder.Entity<DependencyElement>()
                .HasOne(dependElem => dependElem.AttributeCollection)
                .WithMany(attrCol => attrCol.DependencyElements)
                .HasForeignKey(attrCol => attrCol.AttributeCollectionId);
            modelBuilder.Entity<DependencyElement>()
                .HasOne(dependElem => dependElem.FunctionalDependency)
                .WithMany(funcDepend => funcDepend.DependencyElements)
                .HasForeignKey(dependElem => dependElem.FunctionalDependencyId);

            modelBuilder.Entity<FunctionalDependency>()
                .HasMany(funcDepend => funcDepend.DependencyElements)
                .WithOne(dependElem => dependElem.FunctionalDependency)
                .HasForeignKey(dependElem => dependElem.FunctionalDependencyId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

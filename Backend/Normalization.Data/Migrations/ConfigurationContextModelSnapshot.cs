﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Normalization.Data.Contexts;

namespace Normalization.Data.Migrations
{
    [DbContext(typeof(ConfigurationContext))]
    partial class ConfigurationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Normalization.Data.Models.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColumnName");

                    b.HasKey("Id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Normalization.Data.Models.AttributeCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("AttributeCollections");
                });

            modelBuilder.Entity("Normalization.Data.Models.DependencyElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeCollectionId");

                    b.Property<int>("FunctionalDependencyId");

                    b.Property<bool>("IsLeft");

                    b.HasKey("Id");

                    b.HasIndex("AttributeCollectionId");

                    b.HasIndex("FunctionalDependencyId");

                    b.ToTable("DependencyElements");
                });

            modelBuilder.Entity("Normalization.Data.Models.FunctionalDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("FunctionalDependencies");
                });

            modelBuilder.Entity("Normalization.Data.Models.KeyGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeCollectionId");

                    b.HasKey("Id");

                    b.HasIndex("AttributeCollectionId");

                    b.ToTable("KeyGroups");
                });

            modelBuilder.Entity("Normalization.Data.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Normalization.Data.Models.TableAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeId");

                    b.Property<int>("TableId");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("TableId");

                    b.ToTable("TableAttributes");
                });

            modelBuilder.Entity("Normalization.Data.Models.TableAttributeCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeCollectionId");

                    b.Property<int>("TableAttributeId");

                    b.HasKey("Id");

                    b.HasIndex("AttributeCollectionId");

                    b.HasIndex("TableAttributeId");

                    b.ToTable("TableAttributeCollections");
                });

            modelBuilder.Entity("Normalization.Data.Models.DependencyElement", b =>
                {
                    b.HasOne("Normalization.Data.Models.AttributeCollection", "AttributeCollection")
                        .WithMany("DependencyElements")
                        .HasForeignKey("AttributeCollectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Normalization.Data.Models.FunctionalDependency", "FunctionalDependency")
                        .WithMany("DependencyElements")
                        .HasForeignKey("FunctionalDependencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Normalization.Data.Models.KeyGroup", b =>
                {
                    b.HasOne("Normalization.Data.Models.AttributeCollection", "AttributeCollection")
                        .WithMany("KeyGroup")
                        .HasForeignKey("AttributeCollectionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Normalization.Data.Models.TableAttribute", b =>
                {
                    b.HasOne("Normalization.Data.Models.Attribute", "Attribute")
                        .WithMany("TableAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Normalization.Data.Models.Table", "Table")
                        .WithMany("TableAttributes")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Normalization.Data.Models.TableAttributeCollection", b =>
                {
                    b.HasOne("Normalization.Data.Models.AttributeCollection", "AttributeCollection")
                        .WithMany("TableAttributeCollections")
                        .HasForeignKey("AttributeCollectionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Normalization.Data.Models.TableAttribute", "TableAttribute")
                        .WithMany("TableAttributeCollection")
                        .HasForeignKey("TableAttributeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

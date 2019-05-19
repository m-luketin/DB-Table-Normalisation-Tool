﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Normalization.Data.Contexts;

namespace Normalization.Data.Migrations
{
    [DbContext(typeof(ConfigurationContext))]
    [Migration("20190519155817_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Normalization.Data.Models.Attribute", b =>
                {
                    b.Property<int>("PrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColumnName");

                    b.HasKey("PrimaryId");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("Normalization.Data.Models.AttributeCollection", b =>
                {
                    b.Property<int>("PrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("PrimaryId");

                    b.ToTable("AttributeCollections");
                });

            modelBuilder.Entity("Normalization.Data.Models.DependencyElement", b =>
                {
                    b.Property<int>("PrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttributeCollectionPrimaryId");

                    b.Property<bool>("IsLeft");

                    b.HasKey("PrimaryId");

                    b.HasIndex("AttributeCollectionPrimaryId");

                    b.ToTable("DependencyElements");
                });

            modelBuilder.Entity("Normalization.Data.Models.FunctionalDependency", b =>
                {
                    b.Property<int>("PrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DependencyElementPrimaryId");

                    b.HasKey("PrimaryId");

                    b.HasIndex("DependencyElementPrimaryId");

                    b.ToTable("FunctionalDependencies");
                });

            modelBuilder.Entity("Normalization.Data.Models.KeyGroup", b =>
                {
                    b.Property<int>("PrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttributeCollectionPrimaryId");

                    b.HasKey("PrimaryId");

                    b.HasIndex("AttributeCollectionPrimaryId");

                    b.ToTable("KeyGroups");
                });

            modelBuilder.Entity("Normalization.Data.Models.Table", b =>
                {
                    b.Property<int>("PrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("PrimaryId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Normalization.Data.Models.TableAttribute", b =>
                {
                    b.Property<int>("PrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeId");

                    b.Property<int>("TableId");

                    b.HasKey("PrimaryId");

                    b.HasIndex("AttributeId");

                    b.HasIndex("TableId");

                    b.ToTable("TableAttributes");
                });

            modelBuilder.Entity("Normalization.Data.Models.TableAttributeCollection", b =>
                {
                    b.Property<int>("PrimaryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttributeCollectionId");

                    b.Property<int>("TableAttributeId");

                    b.HasKey("PrimaryId");

                    b.HasIndex("AttributeCollectionId");

                    b.HasIndex("TableAttributeId");

                    b.ToTable("TableAttributeCollections");
                });

            modelBuilder.Entity("Normalization.Data.Models.DependencyElement", b =>
                {
                    b.HasOne("Normalization.Data.Models.AttributeCollection", "AttributeCollection")
                        .WithMany("FunctionalDependency")
                        .HasForeignKey("AttributeCollectionPrimaryId");
                });

            modelBuilder.Entity("Normalization.Data.Models.FunctionalDependency", b =>
                {
                    b.HasOne("Normalization.Data.Models.DependencyElement", "DependencyElement")
                        .WithMany("FunctionalDependencies")
                        .HasForeignKey("DependencyElementPrimaryId");
                });

            modelBuilder.Entity("Normalization.Data.Models.KeyGroup", b =>
                {
                    b.HasOne("Normalization.Data.Models.AttributeCollection", "AttributeCollection")
                        .WithMany("KeyGroup")
                        .HasForeignKey("AttributeCollectionPrimaryId");
                });

            modelBuilder.Entity("Normalization.Data.Models.TableAttribute", b =>
                {
                    b.HasOne("Normalization.Data.Models.Table", "Table")
                        .WithMany("TableAttributes")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Normalization.Data.Models.Attribute", "Attribute")
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

﻿using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Normalization.Data.Models;

namespace Normalization.Data.Contexts
{
    public class BaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["NormalizationContext"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IEntity>().HasKey(entity => entity.PrimaryId);
        }
    }
}

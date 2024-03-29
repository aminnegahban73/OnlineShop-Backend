﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductType> ProductTypes => Set<ProductType>();
        public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Finds all classes on this assembly (Infrastructure) which implement "IEntityTypeConfiguration" and put them here
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            // If IsDelete is true, continue.
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDelete);
            modelBuilder.Entity<ProductType>().HasQueryFilter(p => !p.IsDelete);
            modelBuilder.Entity<ProductBrand>().HasQueryFilter(p => !p.IsDelete);
        }
    }

}

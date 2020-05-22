using Data.Entities;
using Data.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductDto>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
            });            
        }
    }
}

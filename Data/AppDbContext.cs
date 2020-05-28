using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        //public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions options)
            : base(options)
        {

        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<User>()
        //           .HasIndex(b => b.Email)
        //           .IsUnique();
        //}
    }
}

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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<User>().ToTable("aspnetusers");
        //    modelBuilder.Entity<IdentityRole<string>>().ToTable("aspnetroles");
        //    modelBuilder.Entity<IdentityUserToken<string>>().ToTable("aspnetusertokens");
        //    modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("aspnetuserclaims");
        //    modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("aspnetuserlogins");
        //    modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("aspnetroleclaims");
        //    modelBuilder.Entity<IdentityUserRole<string>>().ToTable("aspnetuserroles");


        //}
    }
}

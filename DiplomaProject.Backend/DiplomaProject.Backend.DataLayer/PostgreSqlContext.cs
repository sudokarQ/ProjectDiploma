using DiplomaProject.Backend.Common.DataBaseConfigurations;
using DiplomaProject.Backend.Common.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Backend.DataLayer
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext()
        {

        }

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ShopConfiguration());
            modelBuilder.ApplyConfiguration(new ShopUserConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ShopUser> ShopUsers { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}

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
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new PromotionConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ShopUser> ShopUsers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}

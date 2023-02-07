using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using DiplomaProject.Backend.DataLayer.Repositories.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomaProject.Backend.DataLayer.Helpers
{
    public static class DI
    {
        public static void Add(IConfiguration conf, IServiceCollection service)
        {
            AddContext(conf, service);
            AddClass(service);
        }

        private static void AddContext(IConfiguration conf, IServiceCollection service)
        {
            string connection = conf.GetConnectionString("Diplom");

            service.AddDbContext<PostgreSqlContext>(options => options.UseNpgsql(connection));
        }

        private static void AddClass(IServiceCollection service)
        {
            //service.AddScoped<IGenericRepository<Shop>, GenericRepository<Shop>>(); //надо ли до сих пор?
            //service.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
            service.AddScoped<IClientRepository, ClientRepository>();
            service.AddScoped<IShopRepository, ShopRepository>();
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IServiceRepository, ServiceRepository>();
            service.AddScoped<IPromotionRepository, PromotionRepository>();
            service.AddScoped<IShopUserRepository, ShopUserRepository>();
            
            // для каждой модели
        }
    }
}

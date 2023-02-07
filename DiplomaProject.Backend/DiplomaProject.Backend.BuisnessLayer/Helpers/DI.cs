using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Interfaces;
using DiplomaProject.Backend.BuisnessLayer.InterfacesAndServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DiplomaProject.Backend.BuisnessLayer.Helpers
{
    public static class DI
    {
        public static void Add(IConfiguration conf, IServiceCollection service)
        {
            AddClass(service);
            DataLayer.Helpers.DI.Add(conf, service);

        }


        private static void AddClass(IServiceCollection service)
        {
            service.AddScoped<IShopService, ShopService>();
            service.AddScoped<IClientService, ClientService>();
            service.AddScoped<IOrderService, OrderService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IServiceService, ServiceService>();
            service.AddScoped<IPromotionService, PromotionService>();
            service.AddScoped<IShopUserService, ShopUserService>();
            
            
            // для каждой модели
        }
    }
}

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

        }
    }
}

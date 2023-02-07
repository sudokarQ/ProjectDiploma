using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Backend.DataLayer.Repositories.Repos
{
    public class ShopUserRepository : GenericRepository<ShopUser>, IShopUserRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly DbSet<ShopUser> _dbSet;

        public ShopUserRepository(PostgreSqlContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<ShopUser>();
        }
    }
}

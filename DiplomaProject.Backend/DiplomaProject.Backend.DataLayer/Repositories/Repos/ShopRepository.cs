using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Backend.DataLayer.Repositories.Repos
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly DbSet<Shop> _dbSet;

        public ShopRepository(PostgreSqlContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Shop>();
        }

        public Task<Shop> FindByIdAsync(Guid id) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Task<Shop> FindByNameAsync(string name) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
    }
}

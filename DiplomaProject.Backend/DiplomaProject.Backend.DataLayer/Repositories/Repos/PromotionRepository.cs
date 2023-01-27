using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Backend.DataLayer.Repositories.Repos
{
    public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly DbSet<Promotion> _dbSet;

        public PromotionRepository(PostgreSqlContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Promotion>();
        }

        public Task<Promotion> FindByIdAsync(Guid id) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Task<Promotion> FindByNameAsync(string name) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
    }
}

using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Backend.DataLayer.Repositories.Repos
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly DbSet<Order> _dbSet;

        public OrderRepository(PostgreSqlContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Order>();
        }

        public Task<Order> FindByIdAsync(Guid id) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Task<Order> FindByDateAndTimeAsync(DateOnly date, TimeOnly time) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Date == date && x.Time == time);
    }
}

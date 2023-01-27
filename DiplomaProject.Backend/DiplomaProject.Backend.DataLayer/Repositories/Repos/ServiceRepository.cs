using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Backend.DataLayer.Repositories.Repos
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly DbSet<Service> _dbSet;

        public ServiceRepository(PostgreSqlContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Service>();
        }

        public Task<Service> FindByIdAsync(Guid id) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Task<Service> FindByNameAsync(string name) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
    }
}


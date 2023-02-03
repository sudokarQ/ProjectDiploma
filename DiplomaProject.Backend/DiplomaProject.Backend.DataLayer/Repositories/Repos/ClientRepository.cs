using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Backend.DataLayer.Repositories.Repos
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly DbSet<Client> _dbSet;

        public ClientRepository(PostgreSqlContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<Client>();
        }

        public Task<Client> FindByNameAsync(string name) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);
    }
}

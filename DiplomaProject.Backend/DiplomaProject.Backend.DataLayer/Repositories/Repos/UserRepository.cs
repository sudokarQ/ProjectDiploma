using DiplomaProject.Backend.Common.Models.Entity;
using DiplomaProject.Backend.DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DiplomaProject.Backend.DataLayer.Repositories.Repos
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(PostgreSqlContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<User>();
        }

        public Task<User> FindByIdAsync(Guid id) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public Task<User> FindByLoginAsync(string login) => _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Login == login);
    }
}

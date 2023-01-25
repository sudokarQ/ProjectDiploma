using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DiplomaProject.Backend.DataLayer.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PostgreSqlContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(PostgreSqlContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public Task<List<TEntity>> GetAsync() 
            => _dbSet.AsNoTracking().ToListAsync();

        //public List<TEntity> GetAsync(Func<TEntity, bool> predicate) // Исправить
        //{
        //    return _dbSet.Where(predicate).ToList();
        //}

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> FindById(Guid id) => await _dbSet.FindAsync(id);
        
        public async Task<TEntity> FindByName(string name) => await _dbSet.FindAsync(name);

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void CreateAsync(TEntity item)
        {
            _dbSet.AddAsync(item);
            _context.SaveChangesAsync();
        }
        public void Update(TEntity item)
        {
            _dbSet.Update(item);
            _context.SaveChangesAsync();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChangesAsync();
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }
    }
}

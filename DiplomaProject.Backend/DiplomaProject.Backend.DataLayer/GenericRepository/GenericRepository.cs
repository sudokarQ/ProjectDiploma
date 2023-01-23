using Microsoft.EntityFrameworkCore;

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

        //public async Task<List<TEntity>> Get(Func<TEntity, bool> predicate)
        //{
        //    return _dbSet.Where(predicate).AsNoTracking().ToListAsync();
        //}

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _dbSet.Update(item);
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}

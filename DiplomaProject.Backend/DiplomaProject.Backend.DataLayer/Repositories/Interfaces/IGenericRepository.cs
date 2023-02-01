using System.Linq.Expressions;

namespace DiplomaProject.Backend.DataLayer.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity item);
        Task<List<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task RemoveAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    }
}

using System.Linq.Expressions;

namespace DiplomaProject.Backend.DataLayer.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity item);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task RemoveAsync(TEntity item);
        Task UpdateAsync(TEntity item);
        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        Task<List<TEntity>> GetAllAsync();
    }
}

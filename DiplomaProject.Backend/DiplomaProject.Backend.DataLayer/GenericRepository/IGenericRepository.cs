using System.Linq.Expressions;

namespace DiplomaProject.Backend.DataLayer.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void CreateAsync(TEntity item);
        Task<TEntity> FindById(Guid id);
        Task<TEntity> FindByName(string name);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //Task<List<TEntity>> GetAsync(Func<TEntity, bool> predicate);
        //List<TEntity> GetAsync(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TEntity item);
        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        Task<List<TEntity>> GetAsync();
    }
}

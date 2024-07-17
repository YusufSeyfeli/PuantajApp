using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T>
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid id);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<T> GetFirst();
        Task BulkAdd(List<T> entities);
        Task BulkUpdate(List<T> entities);
        Task BulkDelete(List<T> entities);
    }
}

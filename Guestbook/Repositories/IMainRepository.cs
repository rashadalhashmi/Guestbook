using System.Linq.Expressions;

namespace Guestbook.Repositories
{
    public interface IMainRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<IEnumerable<T>> AddRange(IEnumerable<T> entity);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> Update(IEnumerable<T> entity);
        Task<T> Delete(int id);
        Task<IEnumerable<T>> Delete(IEnumerable<T> entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    }
}

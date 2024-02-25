using System.Linq.Expressions;

namespace OnlineCourse.Repository
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> GetSingleById(string id);
        Task<IEnumerable<T>> GetAll();
    }
}

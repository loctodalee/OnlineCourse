using Microsoft.EntityFrameworkCore;
using OnlineCourse.Data;
using OnlineCourse.Data.Entity.Auth;

namespace OnlineCourse.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected OnlineCourseDbContext _context;
        public BaseRepository(OnlineCourseDbContext context)
        {
            _context = context;
        }

        public virtual async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public virtual async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public virtual async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine("-----loi-----");
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public virtual async Task<T> GetSingleById(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SlamBackend.CourseDbContext;

namespace SlamBackend.Repositories
{
    public class GenericRepository<T> where T : class
    {
        protected readonly BackendContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(BackendContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public BackendContext getContext()
        {
            return _context;
        }
    }
}
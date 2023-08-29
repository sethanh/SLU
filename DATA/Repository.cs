using DATA.CONTEXT;
using System.Collections.Generic;
using System.Linq;

namespace DATA
{
    public class Repository<T> where T : class
    {
        private readonly MainDbContext _context;
        public Repository(MainDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T Add(T entity, bool saveChange = false)
        {
            _context.Set<T>().Add(entity);
            if (saveChange)
            {
                _context.SaveChanges();
            }

            return entity;
        }

        public List<T> AddRange(List<T> entity, bool saveChange = false)
        {
            _context.Set<T>().AddRange(entity);
            if (saveChange)
            {
                _context.SaveChanges();
            }

            return entity;
        }

        public T Update(T entity, bool saveChange = false)
        {
            _context.Set<T>().Update(entity);
            if (saveChange)
            {
                _context.SaveChanges();
            }

            return entity;
        }

        public List<T> UpdateRange(List<T> entity, bool saveChange = false)
        {
            _context.Set<T>().UpdateRange(entity);
            if (saveChange)
            {
                _context.SaveChanges();
            }

            return entity;
        }
    }
}

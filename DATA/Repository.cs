using DATA.CONTEXT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> FindAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
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

        public async Task<T> AddAsync(T entity, bool saveChange = false)
        {
            await _context.Set<T>().AddAsync(entity);
            if (saveChange)
            {
                await _context.SaveChangesAsync();
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

        public T Delete_HARD(T entity, bool saveChange = false)
        {
            _context.Set<T>().Remove(entity);
            if (saveChange)
            {
                _context.SaveChanges();
            }

            return entity;
        }

        public List<T> DeleteRange_HARD(List<T> entity, bool saveChange = false)
        {
            _context.Set<T>().RemoveRange(entity);
            if (saveChange)
            {
                _context.SaveChanges();
            }

            return entity;
        }
    }
}

using SERVICE.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVICE
{
    public abstract class ApplicationService<T> where T : class
    {
        protected readonly DomainService<T> _domainService;

        public ApplicationService(DomainService<T> domainService)
        {
            _domainService = domainService;
        }

        public IQueryable<T> GetAll()
        {
            return _domainService.GetAll();
        }

        public T Add(T entity)
        {
            return _domainService.Add(entity, true);
        }

        public List<T> AddRange(List<T> entities)
        {
            return _domainService.AddRange(entities, true);
        }

        public T Update(T entity)
        {
            return _domainService.Update(entity, true);
        }

        public List<T> UpdateRange(List<T> entities)
        {
            return _domainService.UpdateRange(entities, true);
        }

        public void ResetTracker()
        {
            _domainService.ResetTracker();
        } 
    }
}

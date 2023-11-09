using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVICE
{
    public class DomainService<T> where T : class
    {
        public readonly Repository<T> Repository;

        public readonly UnitOfWork _unitOfWork;

        public DomainService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Repository = _unitOfWork.GetRepository<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T Add(T entity, bool saveChange = false)
        {
            Repository.Add(entity, saveChange);
            return entity;
        }

        public List<T> AddRange(List<T> entity, bool saveChange = false)
        {
            Repository.AddRange(entity, saveChange);
            return entity;
        }

        public T Update(T entity, bool saveChange = false)
        {
            Repository.Update(entity, saveChange);
            return entity;
        }

        public List<T> UpdateRange(List<T> entity, bool saveChange = false)
        {
            Repository.UpdateRange(entity, saveChange);
            return entity;
        }

        public void ResetTracker()
        {
            _unitOfWork.ResetTracker();
        } 
    }
}

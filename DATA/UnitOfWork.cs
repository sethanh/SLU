using DATA.CONTEXT;
using Microsoft.EntityFrameworkCore.Storage;

namespace DATA
{
    public class UnitOfWork
    {
        public readonly MainDbContext Context;

        public UnitOfWork(MainDbContext context)
        {
            Context = context;
        }

        public Repository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(Context);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void ResetTracker()
        {
            Context.ResetTracker();
        }
    }

}

using Orange.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Orange.Data.Repositories
{
    public class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected DbSet<T> DbSet;
        protected ApplicationDbContext context;

        public Repository(ApplicationDbContext dataContext)
        {
            context = dataContext;
            DbSet = dataContext.Set<T>();
        }

        public T Insert(T entity)
        {
            return DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet;
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

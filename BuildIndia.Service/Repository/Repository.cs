using BuildIndia.Data;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BuildIndia.Service.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        private readonly NasscomEntities _context;
        public Repository()
        {
            _context = new NasscomEntities();
        }

        public virtual IQueryable<T> GetAll()
        {
            var query = _context.Set<T>();
            return query;
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _context.Entry(entity).State = System.Data.EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

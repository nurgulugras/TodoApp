using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerApp.Data
{
    public interface IRepository<T> where T:class
    {
         Task<T> GetEntityByIdAsync(int id);
         Task<List<T>> GetsAsync(Expression<Func<T, bool>> predicate = null);
         Task<T> SaveAsync(T entity);
         Task DeleteAsync(T entity);
    }
}
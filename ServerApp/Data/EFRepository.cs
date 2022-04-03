using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Data
{
    public class EFRepository<T> : IRepository<T> where T : class,IEntity
    {
        private readonly DataContext _context;

        public EFRepository(DataContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
           await SaveChangesAsync();
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(i=>i.Id == id);
        }

        public Task<List<T>> GetsAsync(Expression<Func<T, bool>> predicate = null)
        {
            return predicate==null?_context.Set<T>().ToListAsync() : _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> SaveAsync(T entity)
        {
            _context.Add(entity);
            await SaveChangesAsync();
            return entity;

        }
        private async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync()>0;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly DbContext DbContext;

        protected RepositoryBase(DbContext dbContext) {
            DbContext = dbContext;
        }


        public async Task<T> GetAsync(int id) {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync() {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyCollection<T>> GetWhereAsync(Expression<Func<T, bool>> predicate) {
            return await DbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(T item) {
            await DbContext.Set<T>().AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<T> items) {
            await DbContext.Set<T>().AddRangeAsync(items);
        }

        public void Remove(T item) {
            DbContext.Set<T>().Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items) {
            DbContext.RemoveRange(items);
        }
    }
}

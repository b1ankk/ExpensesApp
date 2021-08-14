using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExpensesApp.Server.Data.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetAsync(int id);
        public Task<IReadOnlyCollection<T>> GetAllAsync();
        public Task<IReadOnlyCollection<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);

        public Task AddAsync(T item);
        public Task AddRangeAsync(IEnumerable<T> items);

        public void Remove(T item);
        public void RemoveRange(IEnumerable<T> items);
    }
}

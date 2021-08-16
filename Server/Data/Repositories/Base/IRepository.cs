using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExpensesApp.Shared.Utility.Sorting;

namespace ExpensesApp.Server.Data.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        public Task<T> GetAsync(int id);
        public Task<IReadOnlyCollection<T>> GetAllAsync(params SortOrderKey<T>[] orderKeys);
        public Task<IReadOnlyCollection<T>> GetAllWhereAsync(
            Expression<Func<T, bool>> predicate,
            params SortOrderKey<T>[] orderKeys
        );
        public Task<IReadOnlyCollection<T>> GetPagedAsync(
            int pageSize,
            int pageIndex,
            params SortOrderKey<T>[] orderKeys
        );
        public Task<IReadOnlyCollection<T>> GetPagedWhereAsync(
            int pageSize,
            int pageIndex,
            Expression<Func<T, bool>> predicate,
            params SortOrderKey<T>[] orderKeys
        );

        public Task AddAsync(T item);
        public Task AddRangeAsync(IEnumerable<T> items);

        public void Remove(T item);
        public void RemoveRange(IEnumerable<T> items);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExpensesApp.Shared.Utility.Sorting;
using Microsoft.EntityFrameworkCore;

namespace ExpensesApp.Server.Data.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private const int MaxItemsForPage = int.MaxValue;
        private const int DefaultPageIndex = 0;
        private static readonly Expression<Func<T, bool>> DefaultPredicate = x => true;

        protected readonly DbContext DbContext;

        protected RepositoryBase(DbContext dbContext) {
            DbContext = dbContext;
        }


        public async Task<T> GetAsync(int id) {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(params SortOrderKey<T>[] orderKeys) {
            IReadOnlyCollection<T> result = await GetAllWhereAsync(DefaultPredicate);
            return result;
        }

        public async Task<IReadOnlyCollection<T>> GetAllWhereAsync(
            Expression<Func<T, bool>> predicate,
            params SortOrderKey<T>[] orderKeys
        ) {
            IReadOnlyCollection<T> result = await GetPagedWhereAsync(MaxItemsForPage, DefaultPageIndex, predicate, orderKeys);
            return result;
        }

        public async Task<IReadOnlyCollection<T>> GetPagedAsync(
            int pageSize,
            int pageIndex,
            params SortOrderKey<T>[] orderKeys
        ) {
            IReadOnlyCollection<T> result = await GetPagedWhereAsync(pageSize, pageIndex, DefaultPredicate, orderKeys);
            return result;
        }

        public async Task<IReadOnlyCollection<T>> GetPagedWhereAsync(
            int pageSize,
            int pageIndex,
            Expression<Func<T, bool>> predicate,
            params SortOrderKey<T>[] orderKeys
        ) {
            IQueryable<T> query = DbContext.Set<T>()
                                           .Where(predicate)
                                           .OrderByAll(orderKeys)
                                           .Skip(pageSize * pageIndex)
                                           .Take(pageSize);
            List<T> result = await query.ToListAsync();
            return result;
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


    internal static class QuerySortExtension
    {
        internal static IQueryable<T> OrderByAll<T>(this IQueryable<T> query, params SortOrderKey<T>[] orderKeys) {
            if (orderKeys.Length == 0)
                return query;

            IOrderedQueryable<T> ordered = query.OrderedBy(orderKeys[0]);
            ordered = orderKeys.Skip(1).Aggregate(ordered, ThenOrderedBy);
            return ordered;
        }

        private static IOrderedQueryable<T> OrderedBy<T>(this IQueryable<T> query, SortOrderKey<T> orderKey) {
            IOrderedQueryable<T> ordered =
                orderKey.SortDirection == SortDirection.Descending
                    ? query.OrderByDescending(orderKey.Key)
                    : query.OrderBy(orderKey.Key);
            return ordered;
        }

        private static IOrderedQueryable<T> ThenOrderedBy<T>(this IOrderedQueryable<T> query, SortOrderKey<T> orderKey) {
            query = orderKey.SortDirection == SortDirection.Descending
                ? query.ThenByDescending(orderKey.Key)
                : query.ThenBy(orderKey.Key);
            return query;
        }
    }
}

using System.Linq;
using ExpensesApp.Shared.Utility.Sorting;

namespace ExpensesApp.Server.Data.Repositories.Base.QueryableExtensions
{
    public class QueryableExtender : IQueryableExtender
    {
        public IOrderedQueryable<T> OrderedBy<T>(IQueryable<T> query, params SortOrderKey<T>[] orderKeys) {
            if (orderKeys.Length == 0)
                return OrderedById(query);

            IOrderedQueryable<T> ordered = OrderedBy(query, orderKeys[0]);
            ordered = orderKeys.Skip(1).Aggregate(ordered, ThenOrderedBy);
            return ordered;
        }

        private static IOrderedQueryable<T> OrderedBy<T>(IQueryable<T> query, SortOrderKey<T> orderKey) {
            IOrderedQueryable<T> ordered =
                orderKey.SortDirection == SortDirection.Descending
                    ? query.OrderByDescending(orderKey.Key)
                    : query.OrderBy(orderKey.Key);
            return ordered;
        }

        private static IOrderedQueryable<T> ThenOrderedBy<T>(IOrderedQueryable<T> query, SortOrderKey<T> orderKey) {
            query = orderKey.SortDirection == SortDirection.Descending
                ? query.ThenByDescending(orderKey.Key)
                : query.ThenBy(orderKey.Key);
            return query;
        }

        public IOrderedQueryable<T> OrderedById<T>(IQueryable<T> query) {
            IOrderedQueryable<T> result = query.OrderBy(x => x);
            return result;
        }

        public IQueryable<T> Paged<T>(IOrderedQueryable<T> query, int pageSize, int pageIndex) {
            IQueryable<T> result = query.Skip(pageSize * pageIndex).Take(pageSize);
            return result;
        }
        
        
    }
}

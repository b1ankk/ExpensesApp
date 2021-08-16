using System.Linq;
using ExpensesApp.Shared.Utility.Sorting;

namespace ExpensesApp.Server.Data.Repositories.Base.QueryableExtensions
{
    internal static class QueryableExtensions
    {
        private static readonly IQueryableExtender Extender;

        static QueryableExtensions() {
            Extender = new QueryableExtender();
        }


        internal static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, params SortOrderKey<T>[] orderKeys) {
            return Extender.OrderedBy(query, orderKeys);
        }

        internal static IOrderedQueryable<T> OrderById<T>(this IQueryable<T> query) {
            return Extender.OrderedById(query);
        }

        internal static IQueryable<T> GetPage<T>(this IOrderedQueryable<T> query, int pageSize, int pageIndex) {
            return Extender.Paged(query, pageSize, pageIndex);
        }
    }
}

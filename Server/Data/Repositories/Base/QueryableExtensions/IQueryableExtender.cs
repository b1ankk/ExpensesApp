using System.Linq;
using ExpensesApp.Shared.Utility.Sorting;

namespace ExpensesApp.Server.Data.Repositories.Base.QueryableExtensions
{
    public interface IQueryableExtender
    {
        public IOrderedQueryable<T> OrderedBy<T>(IQueryable<T> query, params SortOrderKey<T>[] orderKeys);

        public IOrderedQueryable<T> OrderedById<T>(IQueryable<T> query);

        public IQueryable<T> Paged<T>(IOrderedQueryable<T> query, int pageSize, int pageIndex);
    }
}

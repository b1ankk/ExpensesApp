using System;
using System.Linq.Expressions;

namespace ExpensesApp.Shared.Utility.Sorting
{
    public class SortOrderKey<T>
    {
        public Expression<Func<T, object>> Key { get; private set; }
        public SortDirection SortDirection { get; private set; }
        
        public static SortOrderKey<T> AscendingForKey(Expression<Func<T, object>> key) {
            return new SortOrderKey<T> {
                Key = key,
                SortDirection = SortDirection.Ascending
            };
        }
        
        public static SortOrderKey<T> DescendingForKey(Expression<Func<T, object>> key) {
            return new SortOrderKey<T> {
                Key = key,
                SortDirection = SortDirection.Descending
            };
        }
    }
    
}

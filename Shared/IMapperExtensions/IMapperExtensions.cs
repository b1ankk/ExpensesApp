using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace ExpensesApp.Shared.IMapperExtensions
{
    public static class AutoMapperExtensions
    {
        public static ICollection<TDestination> MapAll<TDestination>(this IMapper mapper, IEnumerable<object> items)
        {
            return items.Select(mapper.Map<TDestination>).ToList();
        }
    }
}

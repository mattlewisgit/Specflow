using System.Collections.Generic;
using System.Linq;

namespace Vitality.Website.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IGrouping<int, TElement>> GroupIntoRows<TElement>(this IEnumerable<TElement> enumerable, int elementsPerRow)
        {
            return enumerable.Select((element, index) => new { Value = element, Key = index }).GroupBy(kv => kv.Key / elementsPerRow, kv => kv.Value);
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Vitality.Website.Extensions
{
    using System;

    public static class EnumerableExtensions
    {
        public static IEnumerable<IGrouping<int, TElement>> GroupIntoRows<TElement>(this IEnumerable<TElement> enumerable, int elementsPerRow)
        {
            return enumerable.Select((element, index) => new { Value = element, Key = index }).GroupBy(kv => kv.Key / elementsPerRow, kv => kv.Value);
        }

        public static IEnumerable<IGrouping<TKey, TElement>> GroupConsecutiveMatches<TKey, TElement>(this IEnumerable<TElement> enumerable, Func<TElement, TKey> keySelector)
        {
            if (enumerable != null)
            {
                var sequence = enumerable.ToArray();
                if (sequence.Any())
                {
                    var key = keySelector(sequence.First());
                    var list = new List<TElement>();
                    foreach (var element in sequence)
                    {
                        if (!keySelector(element).Equals(key))
                        {
                            yield return list.GroupBy(e => key).First();
                            key = keySelector(element);
                            list = new List<TElement>();
                        }
                        list.Add(element);
                    }
                    yield return list.GroupBy(e => key).First();
                }
            }
        }
    }
}
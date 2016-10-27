namespace Vitality.Website.SC.Extensions
{
    using System.Collections.Generic;

    public static class IDictionaryExtensions
    {
        public static IDictionary<TKey, TValue> AddRange<TKey, TValue>
            (this IDictionary<TKey, TValue> source, IDictionary<TKey, TValue> range)
        {
            foreach (var kvp in range)
            {
                source.Add(kvp.Key, kvp.Value);
            }

            return source;
        }
    }
}

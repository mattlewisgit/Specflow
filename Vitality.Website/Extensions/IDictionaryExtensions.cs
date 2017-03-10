namespace Vitality.Website.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class IDictionaryExtensions
    {
        public static IDictionary<TKey, TValue> AddOrOverwrite<TKey, TValue>
            (this IDictionary<TKey, TValue> source, TKey key, TValue value)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (source.ContainsKey(key))
            {
                source.Remove(key);
            }

            source.Add(key, value);
            return source;
        }
    }
}

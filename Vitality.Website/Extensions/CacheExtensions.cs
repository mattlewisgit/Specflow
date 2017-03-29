using System;
using System.Runtime.Caching;

namespace Vitality.Website.Extensions
{
    public static class CacheExtensions
    {
        public static T AddOrGet<T>(
            this ObjectCache cache,
            string key,
            Func<T> func,
            DateTimeOffset absoluteExpiration
        )
            where T : class
        {
            var obj = cache.Get(key) as T;

            if (obj != null)
            {
                return obj;
            }

            obj = func();
            cache.Add(key, obj, absoluteExpiration);

            return obj;
        }
    }
}

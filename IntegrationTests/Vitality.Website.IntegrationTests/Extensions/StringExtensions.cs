using System.Linq;

namespace Kingfisher.Website.IntegrationTests.Extensions
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides extension methods for the native
    /// <see cref="string">enumerable</see> type.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Compares strings while ignoring case, culture and leading whitespace.
        /// </summary>
        /// <param name="source">Source value</param>
        /// <param name="value">To compare against</param>
        /// <returns>Equality</returns>
        /// <exception cref="ArgumentNullException">When either string is null</exception>
        public static bool LooseEquals(this string source, string value)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return source
                .Trim()
                .Equals(value, StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Compares strings while ignoring case, culture and leading whitespace.
        /// </summary>
        /// <param name="source">Source List</param>
        /// <param name="target">To compare against</param>
        /// <returns>Equality</returns>
        /// <exception cref="ArgumentNullException">When either string is null</exception>
        public static bool CompareLists(this List<string> source, List<string> target)
        {
            if (source.Count != target.Count)
                return false;

            return !source.Where((t, i) => t != target[i]).Any();
        }
    }
}

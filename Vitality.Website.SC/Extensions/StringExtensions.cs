namespace Vitality.Website.SC.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class StringExtensions
    {
        public static string Replace(this string source, IDictionary<string, string> replacements)
        {
            return replacements.Aggregate(source, (agg, kvp) => agg.Replace(kvp.Key, kvp.Value));
        }
    }
}

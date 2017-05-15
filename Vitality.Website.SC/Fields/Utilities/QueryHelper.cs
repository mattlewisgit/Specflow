using System;
using Sitecore.Data.Items;

namespace Vitality.Website.SC.Utilities
{
    public static class QueryHelper
    {
        public const string QueryStartText = "query:";

        public static string ResolveQuery(this string query, ItemAxes axes)
        {
            var cleanQuery = query.Substring(QueryStartText.Length);
            return !string.IsNullOrWhiteSpace(cleanQuery) && axes?.SelectSingleItem(cleanQuery) != null
                 ? axes?.SelectSingleItem(cleanQuery).Paths.FullPath ?? string.Empty : string.Empty;
        }
    }
}

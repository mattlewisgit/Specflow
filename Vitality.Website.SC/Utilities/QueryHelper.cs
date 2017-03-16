using Sitecore.Data.Items;

namespace Vitality.Website.SC.Utilities
{
    public static class QueryHelper
    {
        public const string QueryStartText = "query:";

        public static string ResolveQuery(this string query, ItemAxes axes)
        {
            var cleanQuery = query.Substring(QueryStartText.Length);
            var queryItem = axes.SelectSingleItem(cleanQuery);
            return queryItem != null ? queryItem.Paths.FullPath : string.Empty;
        }
    }
}

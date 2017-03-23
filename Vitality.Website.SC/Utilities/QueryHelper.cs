using Sitecore.Data.Items;

namespace Vitality.Website.SC.Utilities
{
    public static class QueryHelper
    {
        public const string QueryStartText = "query:";

        public static string ResolveQuery(this string query, ItemAxes axes)
        {
            query = query.Substring(QueryStartText.Length);
            var queryItem = axes.SelectSingleItem(query);
            return queryItem != null ? queryItem.Paths.FullPath : string.Empty;
        }
    }
}

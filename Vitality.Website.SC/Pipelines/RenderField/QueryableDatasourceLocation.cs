/*https://www.cognifide.com/our-blogs/sitecore/reduce-multisite-chaos-with-sitecore-queries/
 */

using System;
using Sitecore.Pipelines.GetRenderingDatasource;
using Sitecore.Text;

namespace Vitality.Website.SC.Pipelines.RenderField
{
    public class QueryableDatasourceLocation
    {
        private const string QueryStartText = "query:";
        public void Process(GetRenderingDatasourceArgs args)
        {
            foreach (var location in new ListString(args.RenderingItem["Datasource Location"]))
            {
                if (!location.StartsWith(QueryStartText, StringComparison.InvariantCultureIgnoreCase))
                {
                    continue;
                }

                var contextItem = args.ContentDatabase.Items[args.ContextItemPath];
                if (contextItem == null)
                {
                    continue;
                }
                var query = location.Substring(QueryStartText.Length);
                var queryItem = contextItem.Axes.SelectSingleItem(query);
                if (queryItem != null)
                {
                    args.DatasourceRoots.Add(queryItem);
                }
            }
        }
    }
}
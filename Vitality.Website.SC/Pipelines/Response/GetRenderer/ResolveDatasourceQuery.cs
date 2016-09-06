using System;
using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using Vitality.Website.SC.Utilities;

namespace Vitality.Website.SC.Pipelines.Response.GetRenderer
{
    public class ResolveDatasourceQuery : GetRendererProcessor
    {
        public override void Process(GetRendererArgs args)
        {
            var dataSource = args.Rendering.DataSource;
            if (dataSource.StartsWith(QueryHelper.QueryStartText, StringComparison.InvariantCultureIgnoreCase))
            {
                args.Rendering.DataSource = dataSource.ResolveQuery(args.PageContext.Item.Axes);
            }
        }
    }
}

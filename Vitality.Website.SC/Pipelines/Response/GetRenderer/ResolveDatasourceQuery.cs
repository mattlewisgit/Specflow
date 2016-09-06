using System;
using Sitecore.Mvc.Pipelines.Response.GetRenderer;
using Vitality.Website.SC.Utilities;

namespace Vitality.Website.SC.Pipelines.Response.GetRenderer
{
    public class ResolveDatasourceQuery : GetRendererProcessor
    {
        public override void Process(GetRendererArgs args)
        {
            if (args.Rendering.DataSource.StartsWith(QueryHelper.QueryStartText, StringComparison.InvariantCultureIgnoreCase))
            {
                args.Rendering.DataSource = args.Rendering.DataSource.ResolveQuery(args.PageContext.Item.Axes);
            }
        }
    }
}

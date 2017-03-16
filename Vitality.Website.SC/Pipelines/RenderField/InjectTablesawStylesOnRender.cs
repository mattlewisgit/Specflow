namespace Vitality.Website.SC.Pipelines.RenderField
{
    using Sitecore;
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines.RenderField;
    using Sitecore.Web;
    using System;
    using System.Collections.Generic;

    public class InjectTablesawStylesOnRender
    {
        private static IDictionary<string, Func<string, TableSawArgs>> _typeToArgsGenerator =
            new Dictionary<string, Func<string, TableSawArgs>>
            {
                { "stack", TableSawArgs.Stack },
                { "swipe", TableSawArgs.Swipe }
            };

        public void Process(RenderFieldArgs args)
        {
            var content = args.Result.FirstPart;
            Assert.ArgumentNotNull(args, "args");

            if (args.FieldTypeKey != "rich text" || string.IsNullOrWhiteSpace(content))
            {
                return;
            }

            var renderings = Context.Item.Visualization.GetRenderings(Context.Device, false);

            foreach (var rendering in renderings)
            {
                if (string.IsNullOrWhiteSpace(rendering.Settings.DataSource))
                {
                    continue;
                }

                var nameValueCollection = WebUtil.ParseUrlParameters(rendering.Settings.Parameters);
                var tableStyleId = nameValueCollection["TableStyle"]?.ToLowerInvariant();

                if (string.IsNullOrWhiteSpace(tableStyleId))
                {
                    continue;
                }

                var tableStyle = Context.Database.GetItem(tableStyleId)["Value"];

                if (_typeToArgsGenerator.ContainsKey(tableStyle))
                {
                    args.Result.FirstPart = TableSawHelper
                        .AddTableAttributes(_typeToArgsGenerator[tableStyle](content));
                }
            }
        }
    }
}

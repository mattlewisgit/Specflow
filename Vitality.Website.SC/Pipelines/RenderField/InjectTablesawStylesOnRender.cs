using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Query;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.RenderField;
using Sitecore.Web;
using Sitecore.WordOCX;

namespace Vitality.Website.SC.Pipelines.RenderField
{
    public class InjectTablesawStylesOnRender
    {
        public void Process(RenderFieldArgs args)
        {
            var content = args.Result.FirstPart;
            Assert.ArgumentNotNull(args, "args");
            if (args.FieldTypeKey == "rich text" && !string.IsNullOrWhiteSpace(content))
            {
                var renderings = Context.Item.Visualization.GetRenderings(Context.Device, false);
                foreach (var rendering in renderings)
                {
                    if (!string.IsNullOrWhiteSpace(rendering.Settings.DataSource))
                    {
                        var nameValueCollection = WebUtil.ParseUrlParameters(rendering.Settings.Parameters);

                        if (!string.IsNullOrWhiteSpace(nameValueCollection["TableStyle"]))
                        {
                            var tableStyleId = nameValueCollection["TableStyle"].ToLowerInvariant();
                            var tableStyle = Context.Database.GetItem(tableStyleId)["Value"];

                            if (tableStyle == "stack")
                            {
                                args.Result.FirstPart = TableSawHelper.AddTableAttributes(TableSawArgs.Stack(content));
                            }
                            else if (tableStyle == "swipe")
                            {
                                args.Result.FirstPart = TableSawHelper.AddTableAttributes(TableSawArgs.Swipe(content));
                            }
                        }
                    }
                }


            }
        }
    }
}

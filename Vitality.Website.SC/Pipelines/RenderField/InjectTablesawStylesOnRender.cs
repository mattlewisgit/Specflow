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
            Assert.ArgumentNotNull((object)args, "args");
            if (args.FieldTypeKey == "rich text" && !string.IsNullOrWhiteSpace(args.Result.FirstPart))
            {
                var renderings = Sitecore.Context.Item.Visualization.GetRenderings(Sitecore.Context.Device, false);
                foreach (var rendering in renderings)
                {
                    ID datasourceId;
                    if (!string.IsNullOrWhiteSpace(rendering.Settings.DataSource) && ID.TryParse(rendering.Settings.DataSource, out datasourceId) && datasourceId.Equals(args.Item.ID))
                    {
                        var nameValueCollection = WebUtil.ParseUrlParameters(rendering.Settings.Parameters);
                        if (!string.IsNullOrWhiteSpace(nameValueCollection["TableStyle"]))
                        {
                            var tableStyleId = nameValueCollection["TableStyle"].ToLowerInvariant();
                            var tableStyle = Sitecore.Context.Database.GetItem(tableStyleId)["Value"];
                            
                            if (tableStyle == "stack")
                            {
                                args.Result.FirstPart = TableSawHelper.AddTableAttributes(TableSawArgs.Stack(args.Result.FirstPart));
                            }
                            else if (tableStyle == "swipe")
                            {
                                args.Result.FirstPart = TableSawHelper.AddTableAttributes(TableSawArgs.Swipe(args.Result.FirstPart));
                            }
                        }
                    }
                }
                
                
            }
        }
    }
}

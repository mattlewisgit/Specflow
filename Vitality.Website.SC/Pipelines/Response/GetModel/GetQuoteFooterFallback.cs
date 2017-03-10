using System;

namespace Vitality.Website.SC.Pipelines.Response.GetModel
{
    using Sitecore.Data;
    using Sitecore.Mvc.Pipelines.Response.GetModel;
    using Sitecore.Mvc.Presentation;

    public class GetQuoteFooterFallback : GetModelProcessor
    {
        public override void Process(GetModelArgs args)
        {
            Rendering rendering = args.Rendering;
            if (rendering.RenderingItem.ID.Equals(ID.Parse(ItemConstants.Presales.Layout.Renderings.QuoteFooter.Id)))
            {
                var contextItem = rendering.Item;
                // TODO: Consider finding a way to use Glass Models. Currently Glass Models live in Vitality.Website and referencing would cause a circular dependency
                while (contextItem["InheritQuoteFooterSettings"] == "1" && 
                    !string.Equals(contextItem.Paths.Path, ItemConstants.Presales.Content.Home.Path, StringComparison.InvariantCultureIgnoreCase))
                {
                    contextItem = contextItem.Parent;
                }
                rendering.Item = contextItem;
            }
        }
    }
}

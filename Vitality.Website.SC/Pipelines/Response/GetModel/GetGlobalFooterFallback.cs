namespace Vitality.Website.SC.Pipelines.Response.GetModel
{
    using Sitecore.Data;
    using Sitecore.Mvc.Pipelines.Response.GetModel;
    using Sitecore.Mvc.Presentation;

    public class GetGlobalFooterFallback : GetModelProcessor
    {
        public override void Process(GetModelArgs args)
        {
            Rendering rendering = args.Rendering;
            if (rendering.RenderingItem.ID.Equals(ID.Parse("{F643ED45-4AC0-4751-AF89-4F31755527B5}")))
            {
                var contextItem = rendering.Item;
                while (contextItem["InheritGlobalFooterSettings"] == "1" && contextItem.ID.Guid != ItemConstants.Presales.Content.Home.Id)
                {
                    contextItem = contextItem.Parent;
                }
                rendering.Item = contextItem;
            }
        }
    }
}

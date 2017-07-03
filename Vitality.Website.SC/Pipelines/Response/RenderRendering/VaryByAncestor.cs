namespace Vitality.Website.SC.Pipelines.Response.RenderRendering
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Mvc.Pipelines.Response.RenderRendering;

    /// <summary>
    /// Output cache processor to vary caching based on an ancestor with a given template
    /// </summary>
    /// <remarks>
    /// Based on http://www.sitecore.net/learn/blogs/technical-blogs/john-west-sitecore-blog/posts/2014/12/vary-output-caching-by-ancestor-with-template-in-the-sitecore-aspnet-cms.aspx
    /// Added /sitecore/templates/Global/System/VaryByAncestor as base template to builtin Sitecore template /sitecore/templates/System/Layout/Sections/Caching
    /// May require re-adding after a Sitecore version upgrade
    /// </remarks>
    public class VaryByAncestorBasedOnTemplate : RenderRenderingProcessor
    {
        private readonly List<ID> templateIds = new List<ID>();

        private string _query;

        protected string Query
        {
            get
            {
                return _query ?? (_query = string.Format("./ancestor-or-self::*[{0}]",
                    string.Join(" or ", templateIds.Select(id => $"@@templateid='{id}'"))));
            }
        }

        public void AddTemplateById(string templateId)
        {
            Assert.ArgumentNotNullOrEmpty(templateId, "templateId");
            templateIds.Add(ID.Parse(templateId));
        }

        public override void Process(RenderRenderingArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.PageContext, "args.PageContext");
            Assert.ArgumentNotNull(args.PageContext.Database, "args.PageContext.Database");

            if (args.Rendered || HttpContext.Current == null || !args.Cacheable)
            {
                return;
            }

            var rendering = GetRenderingItem(args);

            if (rendering == null || rendering["VaryByAncestor"] != "1")
            {
                return;
            }

            var dataSource = args.PageContext.Item;

            Assert.IsNotNull(dataSource, "dataSource: args.PageContext.Item");

            var firstAncestorWithTemplate = GetAncestorsWithTemplates(dataSource).FirstOrDefault();

            if (firstAncestorWithTemplate != null)
            {
                args.CacheKey += "_#ancestor:" + firstAncestorWithTemplate.ID;
            }
        }

        private Item[] GetAncestorsWithTemplates(Item dataSourceItem)
        {
            return dataSourceItem.Axes.SelectItems(Query) ?? new Item[0];
        }

        private Item GetRenderingItem(RenderRenderingArgs args)
        {
            return args.PageContext.Database.GetItem(args.Rendering.RenderingItem.ID);
        }
    }
}

namespace Vitality.Website.Extensions.Views
{
    using System;

    using Glass.Mapper.Sc.Web.Mvc;

    using Areas.Presales.PageTemplates;
    using SC;

    public static class BasePageExtensions
    {
        //TODO: Consider removing once SEO requirements come in and absolute Urls are managed by Sitecore
        public static string AbsoluteUrl(this GlassView<BasePage> view, string relative)
        {
            return "https://" + Sitecore.Context.Site.HostName + relative;
        }

        public static bool IsHomePage(this GlassView<BasePage> view)
        {
            return Sitecore.Context.Item.Paths.FullPath.Equals(ItemConstants.Presales.Content.Home.Path, StringComparison.OrdinalIgnoreCase);
        }
    }
}

namespace Vitality.Website.Extensions.Views
{
    using System.Linq;

    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Areas.Presales.ComponentTemplates.Navigation;

    public static class MainNavigationExtensions
    {
        public static object LoginLinkCssClass(this GlassView<MainNavigation> view, LinkItem link)
        {
            if (view.Model.LoginLinks.ElementAt(0) == link)
            {
                return new {@class = "box-button box-button--rounded box-button--secondary box-button--full-width"};
            }
            return new {@class = "box-button box-button--rounded box-button--full-width"};
        }

        public static NavigationSection GetActiveNavigationSection(this GlassView<MainNavigation> view, SitecoreItem contextItem)
        {
            return  view.Model.NavigationSections
                .Where(item => item.SectionLink != null && contextItem.Url.StartsWith(item.SectionLink.Url))
                .OrderByDescending(item => item.SectionLink.Url.Length)
                .FirstOrDefault();
        }
    }
}

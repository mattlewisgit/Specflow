namespace Vitality.Website.Extensions.Models
{
    using System.Linq;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Areas.Presales.ComponentTemplates.Navigation;

    public static class MainNavigationExtensions
    {
        public static NavigationSection GetActiveNavigationSection(this MainNavigation mainNavigation, SitecoreItem contextItem)
        {
            return mainNavigation.NavigationSections
                .Where(item => contextItem.Url.StartsWith(item.SectionLink.Url))
                .OrderByDescending(item => item.SectionLink.Url.Length)
                .FirstOrDefault();
        }
    }
}
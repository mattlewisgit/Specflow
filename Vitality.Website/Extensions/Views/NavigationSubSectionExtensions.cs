namespace Vitality.Website.Extensions.Views
{
    using System.Linq;

    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.Models.Navigation;

    public static class NavigationSubSectionExtensions
    {
        public static string MegaMenuCssClass(this GlassView<NavigationSubSection> view)
        {
            return (view.Model.MainMenuLinks.Any() || view.Model.AdditionalMenuLinks.Any() || view.Model.ShowFeature) ? "section-nav__item--megamenu" : string.Empty;
        }
    }
}
namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.Models.Banners;

    public static class HomeHeroExtensions
    {
        public static string BackgroundImage(this GlassView<HomeHero> view)
        {
            return string.Format("background-image: url('{0}')", view.Model.PosterImage.Src);
        }
    }
}
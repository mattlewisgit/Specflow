namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Areas.Presales.ComponentTemplates.Banners;
    using Areas.Presales.RenderingTemplates;

    public static class HomeHeroExtensions
    {
        public static string BackgroundImage(this GlassView<HomeHero> view)
        {
            return view.Model.PosterImage.ProtectedSrc(width:1200);
        }

        public static string ImageRelativePosition(this GlassView<HomeHero> view)
        {
            if (view.GetRenderingParameters<HomeHeroRendering>().ImageRelativePosition != null)
            {
                return view.GetRenderingParameters<HomeHeroRendering>().ImageRelativePosition.Value;
            }
            return string.Empty;
        }

        public static string FontTheme(this GlassView<HomeHero> view)
        {
            if (view.GetRenderingParameters<HomeHeroRendering>().FontTheme != null)
            {
                return view.GetRenderingParameters<HomeHeroRendering>().FontTheme.Value;
            }
            return string.Empty;
        }
        
        public static string VideoTheme(this GlassView<HomeHero> view)
        {
            return DisplayPlayButton(view) ? "home-hero--video" : string.Empty;
        }

        public static bool DisplayPlayButton(this GlassView<HomeHero> view)
        {
            return !string.IsNullOrEmpty(view.Model.VideoId) || !string.IsNullOrWhiteSpace(view.Model.VideoId);
        }
    }
}

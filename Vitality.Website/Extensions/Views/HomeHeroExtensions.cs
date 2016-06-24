﻿namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.ComponentTemplates.Banners;
    using Vitality.Website.Areas.Presales.RenderingTemplates;

    public static class HomeHeroExtensions
    {
        public static string BackgroundImage(this GlassView<HomeHero> view)
        {
            return string.Format("background-image: url('{0}')", view.Model.PosterImage.Src);
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
    }
}
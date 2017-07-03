using Glass.Mapper.Sc.Web.Mvc;

namespace Vitality.Website.Extensions.Views
{
    using Areas.Presales.ComponentTemplates.Partners;
    using Areas.Presales.RenderingTemplates;

    public static class PartnerHeroExtensions
    {
        public static string BackgroundImage(this GlassView<PartnerHero> view)
        {
            if (!string.IsNullOrWhiteSpace(view.Model.BackgroundImage.Src))
            {
                return view.Model.BackgroundImage.ProtectedSrc(width:1200);
            }
            return string.Empty;
        }

        public static string ImageRelativePosition(this GlassView<PartnerHero> view)
        {
            if (view.GetRenderingParameters<PartnerHeroRendering>().ImageRelativePosition != null)
            {
                return view.GetRenderingParameters<PartnerHeroRendering>().ImageRelativePosition.Value;
            }
            return string.Empty;
        }

        public static string FontTheme(this GlassView<PartnerHero> view)
        {
            if (view.GetRenderingParameters<PartnerHeroRendering>().FontTheme != null)
            {
                return view.GetRenderingParameters<PartnerHeroRendering>().FontTheme.Value;
            }
            return "text-dark";
        }

        public static string ColumnSpan(this GlassView<PartnerHero> view)
        {
            if (ShowPartnerCard(view))
            {
                return "grid-col-6-12";
            }
            return "grid-col-12-12";
        }

        public static bool ShowPartnerCard(this GlassView<PartnerHero> view)
        {
            return !string.IsNullOrWhiteSpace(view.Model.PartnerIcon.Src) 
                || !string.IsNullOrWhiteSpace(view.Model.PartnerName) 
                || !string.IsNullOrWhiteSpace(view.Model.Line)
                || !string.IsNullOrWhiteSpace(view.Model.Benefits)
                || view.IsInEditingMode;
        }

        public static string PartnerWithCardClass(this GlassView<PartnerHero> view)
        {
            if (ShowPartnerCard(view))
            {
                return "partner-hero--with-card";
            }
            return null;
        }
    }
}

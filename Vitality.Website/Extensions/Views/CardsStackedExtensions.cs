namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.ComponentTemplates.Cards;
    using Vitality.Website.Areas.Presales.RenderingTemplates;

    public static class CardsStackedExtensions
    {
        public static string BackgroundClass(this GlassView<CardsStacked> view)
        {
            if (string.IsNullOrWhiteSpace(view.Model.BackgroundImage.Src))
            {
                return "text-dark";
            }
            return "background-position-top-right";
        }

        public static string BackgroundStyle(this GlassView<CardsStacked> view)
        {
            if (!string.IsNullOrWhiteSpace(view.Model.BackgroundImage.Src))
            {
                return view.Model.BackgroundImage.ProtectedSrc(width:1200);
            }
            return string.Empty;
        }

        public static bool ImageOnTop(this GlassView<CardsStacked> view)
        {
            return view.GetRenderingParameters<CardsStackedRendering>().ImageOnTop;
        }
    }
}

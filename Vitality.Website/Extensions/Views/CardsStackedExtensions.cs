namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;
    using Vitality.Website.Areas.Presales.Models.Cards;

   public static class CardsStackedExtensions
    {
        public static string BackgroundClass(this GlassView<CardsStacked> view)
        {
            return view == null || string.IsNullOrWhiteSpace(view.GetRenderingParameters<CardsStacked>().BackgroundImage.Src)
                ? "text-dark"
                : "background-position-top-right";
        }

        public static string BackgroundStyle(this GlassView<CardsStacked> view)
        {
            if (view == null)
            {
                return string.Empty;
            }

            var imageSource = view.GetRenderingParameters<CardsStacked>().BackgroundImage.Src;

            return !string.IsNullOrWhiteSpace(imageSource)
                ? "background-size: cover; background-image: url(" + imageSource + ");"
                : string.Empty;
        }
    }
}

namespace Vitality.Website.Extensions.Views
{
    using Vitality.Website.Areas.Presales.Models.Cards;

    /// <summary>
    /// Provides extension methods for <see cref="CardsStacked">CardsStacked</see>.
    /// </summary>
    public static class CardsStackedExtensions
    {
        /// <summary>
        /// Provides a class to position the background image if available,
        /// otherwise defaults to a dark theme.
        /// </summary>
        /// <param name="source">View model</param>
        /// <returns>CSS class</returns>
        public static string BackgroundClass(this CardsStacked source)
        {
            return source == null || string.IsNullOrWhiteSpace(source.BackgroundImage.Src)
                ? "text-dark"
                : "background-position-top-right";
        }

        /// <summary>
        /// Provides to style a background image if available.
        /// </summary>
        /// <param name="source">View model</param>
        /// <returns>CSS style</returns>
        public static string BackgroundStyle(this CardsStacked source)
        {
            if (source == null)
            {
                return string.Empty;
            }

            var imageSource = source.BackgroundImage.Src;

            return !string.IsNullOrWhiteSpace(imageSource)
                ? "background-size: cover; background-image: url(" + imageSource + ");"
                : string.Empty;
        }
    }
}

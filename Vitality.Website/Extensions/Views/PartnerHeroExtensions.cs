using Glass.Mapper.Sc.Web.Mvc;
using Vitality.Website.Areas.Presales.Models.Partners;

namespace Vitality.Website.Extensions.Views
{
    public static class PartnerHeroExtensions
    {
        public static string BackgroundImage(this GlassView<PartnerHero> view)
        {
            if (!string.IsNullOrWhiteSpace(view.Model.BackgroundImage.Src))
            {
                return string.Format("background-image: url('" + view.Model.BackgroundImage.Src + "');");
            }
            return string.Empty;
        }

        public static bool ShowPartnerCard(this GlassView<PartnerHero> view)
        {
            return !string.IsNullOrWhiteSpace(view.Model.PartnerIcon.Src) 
                || !string.IsNullOrWhiteSpace(view.Model.PartnerName) 
                || !string.IsNullOrWhiteSpace(view.Model.Line)
                || !string.IsNullOrWhiteSpace(view.Model.Benefits)
                || view.IsInEditingMode;
        }
    }
}
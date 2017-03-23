namespace Vitality.Website.Extensions.Views
{
    using System.Linq;
    using System.Web;

    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.ComponentTemplates.Cards;
    using Vitality.Website.Areas.Presales.ComponentTemplates.Partners;

    public static class CardsTabbedExtensions
    {
        public static HtmlString ResultsCountText(this GlassView<CardsTabbed> view)
        {
            if (view.IsInEditingMode)
            {
                return view.Editable(view.Model, m => m.ResultsCountText);
            }
            return new HtmlString(view.Model.ResultsCountText.Replace("{count}", "<span class='js-filter-matches'>X</span>"));
        }

        public static string PartnerCategories(this GlassView<CardsTabbed> view, PartnerCard partnerCard)
        {
            return string.Join(",", partnerCard.Categories.Select(category => category.Name.ToLowerHyphenatedString()));
        }
    }
}

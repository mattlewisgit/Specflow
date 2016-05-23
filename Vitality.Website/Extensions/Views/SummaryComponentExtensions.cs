namespace Vitality.Website.Extensions.Views
{
    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.Models.Summary;

    public static class SummaryComponentExtensions
    {
        public static bool CanShowLeadIn(this GlassView<SummaryComponent> view)
        {
            return view.IsInEditingMode || !string.IsNullOrWhiteSpace(view.Model.LeftContentLeadIn);
        }

        public static bool CanShowOpeningParagraph(this GlassView<SummaryComponent> view)
        {
            return view.IsInEditingMode || !string.IsNullOrWhiteSpace(view.Model.LeftContentOpeningParagraph);
        }
    }
}
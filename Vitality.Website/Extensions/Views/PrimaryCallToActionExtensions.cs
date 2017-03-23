namespace Vitality.Website.Extensions.Views
{
    using System.Linq;

    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.ComponentTemplates.CallToAction;

    public static class PrimaryCallToActionExtensions
    {
        public static bool DisplayInsertMessage(this GlassView<PrimaryCallToAction> view)
        {
            return !view.Model.Panels.Any();
        }

        public static int NumberOfColumns(this GlassView<PrimaryCallToAction> view)
        {
            return view.Model.Panels.Count();
        }

        public static bool ShowSecondLine(this GlassView<PrimaryCallToAction> view, CallToActionPanel panel)
        {
            return view.IsInEditingMode || !string.IsNullOrWhiteSpace(panel.Headline2);
        }
    }
}

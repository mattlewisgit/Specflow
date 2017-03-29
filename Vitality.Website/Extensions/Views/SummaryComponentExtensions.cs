namespace Vitality.Website.Extensions.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Glass.Mapper.Sc.Web.Mvc;
    using Areas.Presales.ComponentTemplates.Summary;
    using Areas.Presales.RenderingTemplates;
    using Core;
    using SC;

    public static class SummaryComponentExtensions
    {
        public static bool CanShowLeadIn(this GlassView<SummaryComponent> view) =>
            view.IsInEditingMode || !string.IsNullOrWhiteSpace(view.Model.LeftContentLeadIn);

        public static bool CanShowRightContentOpeningParagraph(this GlassView<SummaryComponent> view) =>
            view.IsInEditingMode || !string.IsNullOrWhiteSpace(view.Model.RightContentOpeningParagraph);

        public static bool CanShowCallToAction(this GlassView<SummaryComponent> view) =>
            view.IsInEditingMode || !string.IsNullOrWhiteSpace(view.Model.CallToAction.Text);

        public static IEnumerable<IGrouping<Guid, SummaryListItem>> GroupSummaryListItems
            (this GlassView<SummaryComponent> view) =>
                view.Model.SummaryListItems.GroupConsecutiveMatches(item => item.TemplateId);

        public static string SummaryListClass(this GlassView<SummaryComponent> view, Guid templateId) =>
            templateId == ItemConstants.Presales.Templates.Summary.SummaryListItem.Id
                ? "iconlist--full"
                : string.Empty;

        public static string BackgroundPosition(this GlassView<SummaryComponent> view) =>
            !string.IsNullOrWhiteSpace(view.Model.BackgroundImage.Src)
                ? view.GetRenderingParameters<SummaryComponentRendering>().ImageRelativePosition?.Value ?? string.Empty
                : string.Empty;

        public static string BackgroundImage(this GlassView<SummaryComponent> view) =>
            !string.IsNullOrWhiteSpace(view.Model.BackgroundImage.Src)
                ? view.Model.BackgroundImage.ProtectedSrc(width:1200)
                : string.Empty;
    }
}

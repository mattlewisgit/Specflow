namespace Vitality.Website.Extensions.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.Models.Summary;
    using Vitality.Website.Areas.Presales.RenderingModels;
    using Vitality.Website.SC;

    public static class SummaryComponentExtensions
    {
        public static bool CanShowLeadIn(this GlassView<SummaryComponent> view)
        {
            return view.IsInEditingMode || !string.IsNullOrWhiteSpace(view.Model.LeftContentLeadIn);
        }

        public static bool CanShowLeftContentOpeningParagraph(this GlassView<SummaryComponent> view)
        {
            return view.IsInEditingMode || !string.IsNullOrWhiteSpace(view.Model.LeftContentOpeningParagraph);
        }

        public static bool CanShowRightContentOpeningParagraph(this GlassView<SummaryComponent> view)
        {
            return view.IsInEditingMode || !string.IsNullOrWhiteSpace(view.Model.RightContentOpeningParagraph);
        }

        public static bool CanShowCallToAction(this GlassView<SummaryComponent> view)
        {
            return view.IsInEditingMode || !string.IsNullOrWhiteSpace(view.Model.CallToAction.Text);
        }

        public static IEnumerable<IGrouping<Guid, SummaryListItem>> GroupSummaryListItems(this GlassView<SummaryComponent> view)
        {
            return view.Model.SummaryListItems.GroupConsecutiveMatches(item => item.TemplateId);
        }

        public static string SummaryListClass(this GlassView<SummaryComponent> view, Guid templateId)
        {
            if (templateId == ItemConstants.Presales.Templates.Summary.SummaryListItem.Id)
            {
                return "iconlist--full";
            }
            return string.Empty;
        }

        public static string BackgroundPosition(this GlassView<SummaryComponent> view)
        {
            if (view.GetRenderingParameters<SummaryComponentRendering>().ImageRelativePosition != null && !string.IsNullOrWhiteSpace(view.Model.BackgroundImage.Src))
            {
                return view.GetRenderingParameters<SummaryComponentRendering>().ImageRelativePosition.Value;
            }
            return string.Empty;
        }

        public static string BackgroundImage(this GlassView<SummaryComponent> view)
        {
            if (!string.IsNullOrWhiteSpace(view.Model.BackgroundImage.Src))
            {
                return string.Format("background-image: url('" + view.Model.BackgroundImage.Src + "');");
            }
            return string.Empty;
        }
    }
}
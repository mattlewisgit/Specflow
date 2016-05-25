namespace Vitality.Website.Extensions.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Glass.Mapper.Sc.Web.Mvc;

    using Vitality.Website.Areas.Presales.Models.Summary;
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
    }
}
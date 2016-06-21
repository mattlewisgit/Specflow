namespace Vitality.Website.Areas.Presales.ComponentTemplates.Summary
{
    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.SC;

    public class SummaryListItem : SitecoreItem
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsShortListItem
        {
            get
            {
                return this.TemplateId == ItemConstants.Presales.Templates.Summary.SummaryListItemShort.Id;
            } 
        }
    }
}
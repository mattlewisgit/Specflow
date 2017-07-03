namespace Vitality.Website.Areas.Presales.ComponentTemplates.Summary
{
    using Global.Models;
    using SC;

    public class SummaryListItem : SitecoreItem
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public bool IsShortListItem
        {
            get
            {
                return TemplateId == ItemConstants.Presales.Templates.Summary.SummaryListItemShort.Id;
            } 
        }
    }
}

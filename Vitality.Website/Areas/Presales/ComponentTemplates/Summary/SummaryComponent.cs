namespace Vitality.Website.Areas.Presales.ComponentTemplates.Summary
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class SummaryComponent : SitecoreItem
    {
        public SummaryComponent()
        {
            this.BackgroundImage = new Image();
            this.CallToAction = new Link();
        }

        public string LeftContentLeadIn { get; set; }

        public string LeftContentHeadline { get; set; }
        
        public string LeftContentBody { get; set; }

        public string RightContentHeadline { get; set; }

        public string RightContentOpeningParagraph { get; set; }

        public Image BackgroundImage { get; set; }

        [SitecoreChildren(IsLazy = false)]
        public IEnumerable<SummaryListItem> SummaryListItems { get; set; }

        public Link CallToAction { get; set; }
    }
}

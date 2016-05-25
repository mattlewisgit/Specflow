namespace Vitality.Website.Areas.Presales.Models.Summary
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class SummaryComponent : SitecoreItem
    {
        public string LeftContentLeadIn { get; set; }

        public string LeftContentHeadline { get; set; }

        public string LeftContentOpeningParagraph { get; set; }

        public string LeftContentBody { get; set; }

        public string RightContentHeadline { get; set; }

        public string RightContentOpeningParagraph { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<SitecoreItem> SummaryListItems { get; set; }

        public Link CallToAction { get; set; }
    }
}
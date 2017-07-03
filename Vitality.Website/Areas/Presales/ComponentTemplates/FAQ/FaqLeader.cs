namespace Vitality.Website.Areas.Presales.ComponentTemplates.FAQ
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Global.Models;

    public class FaqLeader : SitecoreItem
    {
        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        [SitecoreChildren]
        public IEnumerable<FaqPreview> Questions { get; set; }

        public Link CallToAction { get; set; }
    }
}

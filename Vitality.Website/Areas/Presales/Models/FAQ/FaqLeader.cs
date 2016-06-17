using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.FAQ
{
    public class FaqLeader : SitecoreItem
    {
        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        [SitecoreChildren]
        public IEnumerable<FaqPreview> Questions { get; set; }

        public Link CallToAction { get; set; }
    }
}
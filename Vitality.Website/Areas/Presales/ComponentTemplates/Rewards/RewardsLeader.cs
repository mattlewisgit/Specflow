namespace Vitality.Website.Areas.Presales.ComponentTemplates.Rewards
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class RewardsLeader : SitecoreItem
    {
        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        public Link CallToAction { get; set; }

        [SitecoreChildren]
        public IEnumerable<ImageLink> Rewards { get; set; }
    }
}
namespace Vitality.Website.Areas.Presales.ComponentTemplates.Partners
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Global.Models;

    public class PartnerCard : SitecoreItem
    {
        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        public Image Image { get; set; }

        public Image Logo { get; set; }

        public Link CallToAction { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<Taxonomy> Categories { get; set; }
    }
}

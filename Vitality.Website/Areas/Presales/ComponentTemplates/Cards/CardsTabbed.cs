namespace Vitality.Website.Areas.Presales.ComponentTemplates.Cards
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

    using Global.Models;
    using Partners;

    public class CardsTabbed : SitecoreItem
    {
        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        public string AllCategoriesText { get; set; }

        public string ResultsCountText { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<PartnerCard> PartnerCards { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<Taxonomy> Categories { get; set; }
    }
}

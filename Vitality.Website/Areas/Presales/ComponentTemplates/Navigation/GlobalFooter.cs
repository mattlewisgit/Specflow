namespace Vitality.Website.Areas.Presales.ComponentTemplates.Navigation
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class GlobalFooter : SitecoreItem
    {
        public Image Logo { get; set; }

        public string CopyrightStatement { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<FooterSection> FooterLinksColumn1 { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<FooterSection> FooterLinksColumn2 { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<FooterSection> FooterLinksColumn3 { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<FooterSocialSection> FooterSocialLinksColumn { get; set; }
    }
}
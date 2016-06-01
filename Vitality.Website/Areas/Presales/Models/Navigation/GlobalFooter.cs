using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.Models.Navigation
{
    using System.Collections.Generic;
    using System.Linq;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;

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

        [SitecoreIgnore]
        public IEnumerable<FooterSection> FooterLinksAllColumns
        {
            get
            {
                var allcolumns = new List<FooterSection>();
                allcolumns.AddRange(this.FooterLinksColumn1);
                allcolumns.AddRange(this.FooterLinksColumn2);
                allcolumns.AddRange(this.FooterLinksColumn3);
                return allcolumns;
            }
        }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<FooterSocialSection> FooterSocialLinksColumn { get; set; }
    }
}
namespace Vitality.Website.Areas.Presales.Models.Navigation
{
    using System.Collections.Generic;
    using System.Linq;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class NavigationSubSection : SitecoreItem
    {
        public Link SubSectionLink { get; set; }

        public string MainMenuHeader { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<LinkItem> MainMenuLinks { get; set; }

        public string AdditionalMenuHeader { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<LinkItem> AdditionalMenuLinks { get; set; }

        public bool ShowFeature { get; set; }

        public string FeatureHeader { get; set; }

        public string FeatureBody { get; set; }

        public Link FeatureLink { get; set; }

        [SitecoreIgnore]
        public bool ShowMegaMenu
        {
            get
            {
                return this.MainMenuLinks.Any() || this.AdditionalMenuLinks.Any() || this.ShowFeature;
            }
        }
    }
}
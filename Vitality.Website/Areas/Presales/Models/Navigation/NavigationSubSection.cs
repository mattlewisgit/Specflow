namespace Vitality.Website.Areas.Presales.Models.Navigation
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class NavigationSubSection : SitecoreItem
    {
        public Link SubSectionLink { get; set; }

        public string MainMenuHeader { get; set; }

        public IEnumerable<LinkItem> MainMenuLinks { get; set; }

        public string AdditionalMenuHeader { get; set; }

        public IEnumerable<LinkItem> AdditionalMenuLinks { get; set; }

        public bool ShowFeature { get; set; }

        public string FeatureHeader { get; set; }

        public string FeatureBody { get; set; }

        public Link FeatureLink { get; set; }
    }
}
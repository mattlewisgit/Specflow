namespace Vitality.Website.Areas.Presales.Models.Navigation
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class NavigationSection : SitecoreItem
    {
        public Link SectionLink { get; set; }

        public Link AdditionalLink { get; set; }

        public string AdditionalLinkSubHeader { get; set; }

        [SitecoreChildren]
        public IEnumerable<NavigationSubSection> NavigationSubSections { get; set; }

        [SitecoreQuery("..", IsRelative = true, IsLazy = false)]
        public MainNavigation MainNavigation { get; set; }
    }
}
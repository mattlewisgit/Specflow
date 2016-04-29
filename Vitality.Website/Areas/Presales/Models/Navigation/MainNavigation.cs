namespace Vitality.Website.Areas.Presales.Models.Navigation
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;

    public class MainNavigation : SitecoreItem
    {
        public Link SearchPage { get; set; }

        public Link ContactUsPage { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<ImageLinkItem> SocialLinks { get; set; }

        public Link LogInLink { get; set; }

        public Image LogInAvatar { get; set; }

        public string LogInHeader { get; set; }

        public string LogInText { get; set; }

        public string RegisterText { get; set; }

        public string ForgottenDetailsText { get; set; }

        [SitecoreChildren]
        public IEnumerable<NavigationSection> NavigationSections { get; set; }
    }
}
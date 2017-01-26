namespace Vitality.Website.Areas.Presales.ComponentTemplates.Navigation
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.SC;

    public class MainNavigation : SitecoreItem
    {
        private const string HasNavigationSectionTemplate = "./*[@@templateid='" + ItemConstants.Presales.Templates.NavigationSection.Id + "']";

        public Image Logo { get; set; }

        public Link SearchPage { get; set; }

        public Image SearchIcon { get; set; }

        public string SearchAltText { get; set; }

        public Link ContactUsPage { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<ImageLink> SocialLinks { get; set; }

        public Image LoginIcon { get; set; }

        public string LogInText { get; set; }

        public string LoginAltText { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<LinkItem> LoginLinks { get; set; }

        [SitecoreQuery(HasNavigationSectionTemplate, IsRelative = true)]
        public IEnumerable<NavigationSection> NavigationSections { get; set; }
    }
}

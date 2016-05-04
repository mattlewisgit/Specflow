namespace Vitality.Website.Areas.Presales.Models.Navigation
{
    using System.Collections.Generic;
    using System.Linq;

    using Glass.Mapper.Sc.Configuration;
    using Glass.Mapper.Sc.Configuration.Attributes;
    using Glass.Mapper.Sc.Fields;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Extensions;

    public class MainNavigation : SitecoreItem
    {
        private const string HasNavigationSectionTemplate = "./*[@@templateid='" + ItemConstants.Presales.Templates.NavigationSection.Id + "']";

        public Link SearchPage { get; set; }

        public Link ContactUsPage { get; set; }

        [SitecoreField(Setting = SitecoreFieldSettings.DontLoadLazily)]
        public IEnumerable<ImageLink> SocialLinks { get; set; }

        public Link LogInLink { get; set; }

        public Image LogInAvatar { get; set; }

        public string LogInHeader { get; set; }

        public string LogInText { get; set; }

        public string RegisterText { get; set; }

        public string ForgottenDetailsText { get; set; }

        [SitecoreQuery(HasNavigationSectionTemplate, IsRelative = true)]
        public IEnumerable<NavigationSection> NavigationSections { get; set; }

        [SitecoreIgnore]
        public NavigationSection ActiveNavigationSection
        {
            get
            {
                return this.NavigationSections.First();
            }
        }
    }
}
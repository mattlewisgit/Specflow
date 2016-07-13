namespace Vitality.Website.IntegrationTests.Extensions
{
    using System;
    using System.Linq;

    using Vitality.Website.Extensions;
    using Vitality.Website.IntegrationTests.PageComponents.Navigation;

    public static class MainNavigationExtensions
    {
        public static void ClickNavigationSectionLink(this MainNavigation mainNavigation, string section)
        {
            var navigationSection = mainNavigation.NavigationSections.FirstOrDefault(e => e.SectionLink.GetAttribute("href").Contains(section));
            if (navigationSection == null)
            {
                throw new ArgumentNullException("Could not find navigation section called {0}".FormatWith(section));
            }
            navigationSection.SectionLink.Click();
        }
    }
}

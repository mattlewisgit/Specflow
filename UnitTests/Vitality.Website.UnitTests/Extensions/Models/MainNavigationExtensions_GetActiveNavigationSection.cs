namespace Vitality.Website.UnitTests.Extensions.Models
{
    using System.Collections.Generic;

    using Glass.Mapper.Sc.Fields;

    using Shouldly;

    using Vitality.Website.Areas.Global.Models;
    using Vitality.Website.Areas.Presales.ComponentTemplates.Navigation;
    using Vitality.Website.Extensions.Models;

    using Xunit;

    public class MainNavigationExtensions_GetActiveNavigationSection
    {
        private readonly MainNavigationBuilder builder = new MainNavigationBuilder();

        [Fact]
        public void No_navigation_sections_should_return_null()
        {
            var mainNavigation = this.builder.Build();
            var contextItem = new SitecoreItem();

            var result = mainNavigation.GetActiveNavigationSection(contextItem);

            result.ShouldBeNull();
        }

        [Fact]
        public void Single_navigation_section_should_return_navigation_section()
        {
            var navigationSection = this.builder.AddNavigationSection("/home");
            var mainNavigation = this.builder.Build();
            var contextItem = new SitecoreItem { Url = "/home/illness-protection" };

            var result = mainNavigation.GetActiveNavigationSection(contextItem);

            result.ShouldBe(navigationSection);
        }

        [Fact]
        public void Selected_navigation_section_should_be_ancestor_of_context_item()
        {
            this.builder.AddNavigationSection("/home/business");
            var selectedNavigationSection = this.builder.AddNavigationSection("/home");
            var mainNavigation = this.builder.Build();
            var contextItem = new SitecoreItem { Url = "/home/illness-protection" };

            var result = mainNavigation.GetActiveNavigationSection(contextItem);

            result.ShouldBe(selectedNavigationSection);
        }

        [Fact]
        public void Given_multiple_ancestors_selected_navigation_section_should_be_nearest_ancestor_of_context_item()
        {
            this.builder.AddNavigationSection("/home");
            var selectedNavigationSection = this.builder.AddNavigationSection("/home/business");
            var mainNavigation = this.builder.Build();
            var contextItem = new SitecoreItem { Url = "/home/business/business-protection" };

            var result = mainNavigation.GetActiveNavigationSection(contextItem);

            result.ShouldBe(selectedNavigationSection);
        }

        private class MainNavigationBuilder
        {
            private readonly List<NavigationSection> navigationSections = new List<NavigationSection>();

            public NavigationSection AddNavigationSection(string url)
            {
                var navigationSection = new NavigationSection { SectionLink = new Link { Url = url } };
                this.navigationSections.Add(navigationSection);
                return navigationSection;
            }

            public MainNavigation Build()
            {
                return new MainNavigation { NavigationSections = this.navigationSections };
            }
        }
    }
}

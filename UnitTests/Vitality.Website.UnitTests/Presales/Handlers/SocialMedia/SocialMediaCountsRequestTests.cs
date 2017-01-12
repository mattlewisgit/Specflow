using System;
using Shouldly;
using Vitality.Website.App.SocialMedia;
using Vitality.Website.Areas.Presales.Handlers.SocialMedia;
using Vitality.Website.Areas.Presales.SettingsTemplates;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.SocialMedia
{
    public class SocialMediaCountsRequestTests
    {
        [Fact]
        public void new_instance_should_assign_all_property_values()
        {
            var result = new SocialMediaCountsRequest(new SocialMediaSettings
            {
                AppKey = "testappkey",
                AppSecret = "testappsecret",
                EntityId = "testentityid",
                SiteIdentifier = "twitter"
            });
            result.EntityId.ShouldBe("testentityid");
            result.SiteIdentifier.ShouldBe("testsite");
            result.SocialMediaConnector.ShouldBeOfType<FacebookConnector>();
        }

        [Fact]
        public void when_site_identifier_is_not_twitter_or_facebook_throw_argument_null_reference_exception()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new SocialMediaCountsRequest(new SocialMediaSettings
            {
                SiteIdentifier = "testsite"
            }));

            Assert.Equal("SiteIdentifier", ex.ParamName);
        }
    }
}

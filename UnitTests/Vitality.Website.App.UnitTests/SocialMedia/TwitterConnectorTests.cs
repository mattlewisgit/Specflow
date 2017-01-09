using Shouldly;
using Vitality.Website.App.SocialMedia;
using Vitality.Website.App.SocialMedia.Models;
using Xunit;

namespace Vitality.Website.App.UnitTests.SocialMedia
{
    public class TwitterConnectorTests
    {
        private static readonly TwitterConnector TwitterConnector = new TwitterConnector(new SocialMediaAccount
        {
            AppKey = "FwmdoMOPe4v3psYi3TSbtOmPt",
            AppSecret = "6yl7v0uwKJqB1vnxP7RNRD52wpqJVWt1z1Bu9qW4rIeoQ82jV9"
        });

        public class GetAccessToken
        {
            [Fact]
            public void Request__should_return_accesstoken()
            {
                TwitterConnector.GetAccessToken().AccessToken.ShouldNotBeNullOrEmpty();
            }
        }

        public class GetLikes
        {
            [Fact]
            public void Request_with_page_id_should_retun_fancount()
            {
                var result = TwitterConnector.GetFollowersOrLikesCount("lakmalvbj", TwitterConnector.GetAccessToken().AccessToken);
                result.ShouldBeGreaterThan(0);
            }
        }
    }
}

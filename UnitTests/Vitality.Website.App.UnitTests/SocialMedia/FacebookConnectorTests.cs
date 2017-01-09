using System;
using System.Net;
using Shouldly;
using Vitality.Website.App.SocialMedia;
using Vitality.Website.App.SocialMedia.Models;
using Xunit;

namespace Vitality.Website.App.UnitTests.SocialMedia
{
    public class FacebookConnectorTests
    {
        private static readonly FacebookConnector FacebookConnector = new FacebookConnector(new SocialMediaAccount
        {
            AppKey = "1633481376904537",
            AppSecret = "d59f86dc81132b6d1db696ee42357f4f"
        });

        public class GetAccessToken
        {
            [Fact]
            public void Request__should_return_accesstoken()
            {
                FacebookConnector.GetAccessToken().AccessToken.ShouldNotBeNullOrEmpty();
            }
        }

        public class GetLikes
        {
            [Fact]
            public void Request_with_page_id_should_retun_fancount()
            {
                var result = FacebookConnector.GetLikesCount(242495902445893.ToString(), FacebookConnector.GetAccessToken().AccessToken);
                result.FanCount.ShouldBeGreaterThan(0);
            }

            [Fact]
            public void Request_with_wrong_access_token_page_id_should_throw_exception_with_401_status_code()
            {
                var ex = Assert.Throws<Exception>(()=> FacebookConnector.GetLikesCount(242495902445893.ToString(), "wrong access token"));
                Assert.Equal(HttpStatusCode.Unauthorized, (HttpStatusCode)ex.Data["StatusCode"]);
            }
        }
    }
}

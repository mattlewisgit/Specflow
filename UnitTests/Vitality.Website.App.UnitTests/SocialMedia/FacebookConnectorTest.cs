using System.Data.Odbc;
using Shouldly;
using Vitality.Website.App.Models.SocialMedia;
using Vitality.Website.App.SocialMedia;
using Xunit;

namespace Vitality.Website.App.UnitTests.SocialMedia
{
    public class FacebookConnectorTest
    {
        public class GetAccessToken
        {
            [Fact]
            public void Correct_creadentials_should_return_accesstoken()
            {
                var facebookConnector = new FacebookConnector(new SocialMediaAccount
                {
                    ClientId = "1633481376904537",
                    ClientSecret = "d59f86dc81132b6d1db696ee42357f4f",
                    GrantType = "client_credentials"
                });
                facebookConnector.GetAccessToken().ShouldStartWith("access_token=");
            }
        }
    }
}

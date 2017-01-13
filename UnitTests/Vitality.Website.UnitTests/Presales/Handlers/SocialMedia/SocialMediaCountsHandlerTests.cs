using System;
using System.Net;
using System.Runtime.Caching;
using log4net;
using Moq;
using Shouldly;
using Vitality.Website.App.SocialMedia.Interfaces;
using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.Areas.Presales.Handlers.SocialMedia;
using Vitality.Website.Areas.Presales.SettingsTemplates;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.SocialMedia
{
    public class SocialMediaCountsHandlerTests
    {
        public class CallSocialConnector
        {
            private static ObjectCache CacheStore = MemoryCache.Default;
            private readonly Mock<ISocialMediaConnector> _socialMediaConnector;
            private readonly SocialMediaCountsHandler _handler;
            private readonly Mock<ILog> _logger;

            public CallSocialConnector()
            {
                _handler =new SocialMediaCountsHandler();
                _socialMediaConnector = new Mock<ISocialMediaConnector>();
                _logger = new Mock<ILog>();
            }

            [Fact(Skip="Issue with jenkins")]
            public void should_read_access_token_from_cache_and_do_not_call_social_media_connector_method()
            {
                //Add the cache value only for 10 second only to be able to run the test 
                CacheStore.Add("twitter_accessToken", new AccessTokenResponse
                    {
                        AccessToken = "testaccesstoken"
                    }
                    , DateTimeOffset.UtcNow.AddSeconds(10));
                _handler.CallSocialConnector(_logger.Object, _socialMediaConnector.Object, "twitter", "testentityid", 0);
                _socialMediaConnector.Verify(smc => smc.GetAccessToken(), Times.Never);
            }

            [Fact(Skip = "Issue with jenkins")]
            public void should_call_accesstoken_request_when_not_found_in_cache()
            {
                _handler.CallSocialConnector(_logger.Object, _socialMediaConnector.Object, "facebook", "testentityid", 0);
                _socialMediaConnector.Verify(smc => smc.GetAccessToken(), Times.Once);
            }

            [Fact(Skip = "Issue with jenkins")]
            public void when_error_occurs_getpopularity_count_should_be_called_twice_when_notauthorize_status_code_returned()
            {
                _socialMediaConnector.Setup(smc => smc.GetAccessToken()).Returns(new AccessTokenResponse());
                var exception = new Exception();
                exception.Data.Add("StatusCode",HttpStatusCode.Unauthorized);
                _socialMediaConnector.Setup(smc => smc.GetPopularityCount(It.IsAny<string>(), It.IsAny<string>()))
                    .Throws(exception);
                Assert.Throws<Exception>(() => _handler.CallSocialConnector(_logger.Object, _socialMediaConnector.Object, "facebook", "testentityid", 0));
                _socialMediaConnector.Verify(smc => smc.GetAccessToken(), Times.Exactly(2));
            }
        }
    }
}

using System;
using System.Net;
using System.Runtime.Caching;
using log4net;
using MediatR;
using Vitality.Website.App.Handlers;
using Vitality.Website.App.SocialMedia;
using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.Areas.Presales.Models;
using Vitality.Website.Extensions;

namespace Vitality.Website.Areas.Presales.Handlers.SocialMedia
{
    public class SocialMediaCountsHandler :IRequestHandler<SocialMediaCountsRequest, SocialMediaCountsDto>
    {
        private static readonly ObjectCache MemoryCacheStore = MemoryCache.Default;
        private static readonly ILog Logger = PresalesLog.Log;

        public SocialMediaCountsDto Handle(SocialMediaCountsRequest request)
        {
            return MemoryCacheStore.AddOrGet(string.Format("{0}_socialMediaCount", request.SiteIdentifier),
                    ()=> CallSocialConnector(request, 0),
                    DateTimeOffset.UtcNow.AddHours(1));
        }

        private SocialMediaCountsDto CallSocialConnector(SocialMediaCountsRequest request, int attempt)
        {
            var socialMediaAccount = new SocialMediaAccount
            {
                AppKey = request.AppKey,
                AppSecret = request.AppSecret
            };

            var accessTokenCacheKey = string.Format("{0}_accessToken", request.SiteIdentifier);
            //Fail gracefully but log it
            try
            {
                if (string.Equals(request.SiteIdentifier, SocialMediaConstants.Facebook,
                    StringComparison.OrdinalIgnoreCase))
                {
                    var facebookConnector = new FacebookConnector(socialMediaAccount);
                    var accessTokenResponse = MemoryCacheStore.AddOrGet(accessTokenCacheKey, facebookConnector.GetAccessToken, DateTimeOffset.UtcNow.AddDays((1)));
                    return SocialMediaCountsDto.From(facebookConnector.GetLikesCount(request.EntityId, accessTokenResponse.AccessToken).FanCount);
                }
                if (string.Equals(request.SiteIdentifier, SocialMediaConstants.Twitter,
                    StringComparison.OrdinalIgnoreCase))
                {
                    var twitterConnector = new TwitterConnector(socialMediaAccount);
                    var accessTokenResponse = MemoryCacheStore.AddOrGet(accessTokenCacheKey, twitterConnector.GetAccessToken, DateTimeOffset.UtcNow.AddDays((1)));
                    return SocialMediaCountsDto.From(twitterConnector.GetFollowersCount(request.EntityId, accessTokenResponse.AccessToken).FollowersCount);
                }
                return SocialMediaCountsDto.From(0);
            }
            catch (Exception ex)
            {
                var statusCode = (HttpStatusCode)ex.Data[ApiResponseHandler.StatusCodeKey];
                //Access token might be expired, clear it from the cache and try again
                if ((statusCode == HttpStatusCode.BadRequest || statusCode == HttpStatusCode.Unauthorized) &&
                    attempt == 0)
                {
                    MemoryCacheStore.Remove(accessTokenCacheKey);
                    CallSocialConnector(request, 1);
                }
                Logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}
namespace Vitality.Website.Areas.Presales.Handlers.SocialMedia
{
    using System;
    using System.Net;
    using System.Runtime.Caching;
    using log4net;
    using MediatR;
    using App.Helpers;
    using App.SocialMedia.Interfaces;
    using Core;

    public class SocialMediaCountsHandler : IRequestHandler<SocialMediaCountsRequest, SocialMediaCountsDto>
    {
        private static readonly ObjectCache MemoryCacheStore = MemoryCache.Default;

        public SocialMediaCountsDto Handle(SocialMediaCountsRequest request) =>
            MemoryCacheStore.AddOrGet(
                $"{request.SiteIdentifier}_socialMediaCount",
                () => CallSocialConnector(PresalesLog.Log, request.SocialMediaConnector, request.SiteIdentifier, request.EntityId, 0),
                DateTimeOffset.UtcNow.AddHours(1));

        public SocialMediaCountsDto CallSocialConnector(
            ILog logger,  ISocialMediaConnector socialMediaConnector,
            string siteIdentifier, string entityId, int attempt)
        {
            var accessTokenCacheKey = string.Format("{0}_accessToken", siteIdentifier);

            try
            {
                var accessTokenResponse = MemoryCacheStore.AddOrGet(
                    accessTokenCacheKey,
                    socialMediaConnector.GetAccessToken,
                    DateTimeOffset.UtcNow.AddDays((1)));

                return SocialMediaCountsDto.From
                    (socialMediaConnector.GetPopularityCount(entityId, accessTokenResponse.AccessToken));
            }
            catch (Exception ex)
            {
                var statusCode = (HttpStatusCode) ex.Data[ApiHelper.StatusCodeKey];

                // The access token might have expired, so clear it from the cache and try again.
                if ((statusCode == HttpStatusCode.BadRequest || statusCode == HttpStatusCode.Unauthorized) &&
                    attempt == 0)
                {
                    MemoryCacheStore.Remove(accessTokenCacheKey);
                    CallSocialConnector(logger, socialMediaConnector, siteIdentifier, entityId, 1);
                }

                logger.Error(ex.Message, ex);
                throw;
            }
        }
    }
}

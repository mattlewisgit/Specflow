using MediatR;
using Vitality.Website.Areas.Presales.SettingsTemplates;

namespace Vitality.Website.Areas.Presales.Handlers.SocialMedia
{
    public class SocialMediaCountsRequest : IRequest<SocialMediaCountsDto>
    {
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string EntityId { get; set; }
        public string SiteIdentifier { get; set; }

        public SocialMediaCountsRequest(SocialMediaSettings settings)
        {
            AppKey = settings.AppKey;
            AppSecret = settings.AppSecret;
            EntityId = settings.EntityId;
            SiteIdentifier = settings.SiteIdentifier;
        }
    }
}
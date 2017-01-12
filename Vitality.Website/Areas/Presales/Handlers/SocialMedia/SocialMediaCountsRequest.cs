using System;
using MediatR;
using Vitality.Website.App.SocialMedia;
using Vitality.Website.App.SocialMedia.Interfaces;
using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.Areas.Presales.SettingsTemplates;

namespace Vitality.Website.Areas.Presales.Handlers.SocialMedia
{
    public class SocialMediaCountsRequest : IRequest<SocialMediaCountsDto>
    {
        public ISocialMediaConnector SocialMediaConnector { get; set; }
        public string EntityId { get; set; }
        public string SiteIdentifier { get; set; }

        public SocialMediaCountsRequest(SocialMediaSettings settings)
        {
            EntityId = settings.EntityId;
            SiteIdentifier = settings.SiteIdentifier;
            var socialMediaAccount = new SocialMediaAccount
            {
                AppKey = settings.AppKey,
                AppSecret = settings.AppSecret
            };

            if (string.Equals(SiteIdentifier, SocialMediaConstants.Facebook,
                StringComparison.OrdinalIgnoreCase))
            {
                SocialMediaConnector = new FacebookConnector(socialMediaAccount);
            }
            else if (string.Equals(SiteIdentifier, SocialMediaConstants.Twitter,
                StringComparison.OrdinalIgnoreCase))
            {
                SocialMediaConnector = new TwitterConnector(socialMediaAccount);
            }
            else
            {
                throw new ArgumentNullException("SiteIdentifier");
            }
        }
    }
}
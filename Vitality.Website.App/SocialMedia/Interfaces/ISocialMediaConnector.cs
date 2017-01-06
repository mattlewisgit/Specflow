
using Vitality.Website.App.SocialMedia.Models.Facebook;

namespace Vitality.Website.App.SocialMedia.Interfaces
{
    public interface ISocialMediaConnector
    {
        AccessTokenResponse GetAccessToken();
    }
}

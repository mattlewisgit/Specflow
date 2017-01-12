using Vitality.Website.App.SocialMedia.Models;

namespace Vitality.Website.App.SocialMedia.Interfaces
{
    public interface ISocialMediaConnector
    {
        AccessTokenResponse GetAccessToken();
        int GetPopularityCount(string id, string accessToken);
    }
}

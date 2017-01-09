using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.App.SocialMedia.Models.Twitter;

namespace Vitality.Website.App.SocialMedia.Interfaces
{
    public interface ITwitterConnector
    {
        AccessTokenResponse GetAccessToken();
        FollowersCountReponse GetFollowersCount(string id, string accessToken);
    }
}

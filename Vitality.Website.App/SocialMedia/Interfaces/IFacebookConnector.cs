using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.App.SocialMedia.Models.Facebook;

namespace Vitality.Website.App.SocialMedia.Interfaces
{
    public interface IFacebookConnector
    {
        AccessTokenResponse GetAccessToken();
        FanCountResponse GetLikesCount(string id, string accessToken);
    }
}

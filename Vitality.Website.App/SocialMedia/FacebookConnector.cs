using RestSharp;
using Vitality.Website.App.Models.SocialMedia;
using Vitality.Website.App.SocialMedia.Interfaces;
using Vitality.Website.App.SocialMedia.Models.Facebook;

namespace Vitality.Website.App.SocialMedia
{
    public class FacebookConnector :ISocialMediaConnector
    {
        private RestClient _restClient; 
        private SocialMediaAccount _socialMediaAccount;

        public FacebookConnector(SocialMediaAccount socialMediaAccount)
        {
            _socialMediaAccount = socialMediaAccount;
            _restClient = new RestClient("https://graph.facebook.com/v2.8");
        }

        public AccessTokenResponse GetAccessToken()
        {
            var url = string.Format(@"/oauth/access_token?client_id={0}&client_secret={1}&grant_type={2}", _socialMediaAccount.ClientId, _socialMediaAccount.ClientSecret, _socialMediaAccount.GrantType);
            var request = new RestRequest(url, Method.GET);
            return _restClient.Execute<AccessTokenResponse>(request).Data;
        }

        public int GetLikes(string pageId, string accessToken)
        {
            var url = string.Format(@"/{0}/?fields=fan_count&access_token={1}", pageId,accessToken);
            var request = new RestRequest(url, Method.GET);
            return _restClient.Execute<FanCountResponse>(request).Data.FanCount;
        }
    }
}

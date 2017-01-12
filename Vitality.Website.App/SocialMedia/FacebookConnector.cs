using RestSharp;
using RestSharp.Authenticators;
using Vitality.Website.App.Handlers;
using Vitality.Website.App.SocialMedia.Interfaces;
using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.App.SocialMedia.Models.Facebook;

namespace Vitality.Website.App.SocialMedia
{
    public class FacebookConnector :ISocialMediaConnector
    {
        private readonly RestClient _restClient; 
        private readonly SocialMediaAccount _socialMediaAccount;

        public FacebookConnector(SocialMediaAccount socialMediaAccount)
        {
            _socialMediaAccount = socialMediaAccount;
            _restClient = new RestClient("https://graph.facebook.com/v2.8");
        }

        public AccessTokenResponse GetAccessToken()
        {
            var request = new RestRequest("/oauth/access_token", Method.GET);
            request.AddQueryParameter("grant_type", "client_credentials");
            _restClient.Authenticator = new SimpleAuthenticator("client_id", _socialMediaAccount.AppKey,
               "client_secret", _socialMediaAccount.AppSecret);
            var response = _restClient.Execute<AccessTokenResponse>(request);
            return response.Handle();
        }

        public int GetPopularityCount(string pageId, string accessToken)
        {
            var url = string.Format(@"/{0}/?fields=fan_count", pageId);
            var request = new RestRequest(url, Method.GET);
            _restClient.Authenticator = new OAuth2UriQueryParameterAuthenticator(accessToken);
            var response =  _restClient.Execute<FanCountResponse>(request);
            return response.Handle().FanCount;
        }
    }
}

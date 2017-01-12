using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;
using RestSharp.Authenticators;
using Vitality.Website.App.Handlers;
using Vitality.Website.App.SocialMedia.Interfaces;
using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.App.SocialMedia.Models.Twitter;

namespace Vitality.Website.App.SocialMedia
{
    public class TwitterConnector : ISocialMediaConnector
    {
        private readonly RestClient _restClient;
        private readonly SocialMediaAccount _socialMediaAccount;

        public TwitterConnector(SocialMediaAccount socialMediaAccount)
        {
            _socialMediaAccount = socialMediaAccount;
            _restClient = new RestClient("https://api.twitter.com/");
        }

        public AccessTokenResponse GetAccessToken()
        {
            var request = new RestRequest("/oauth2/token", Method.POST);
            request.AddHeader(HttpRequestHeader.ContentType.ToString(),
                "application/x-www-form-urlencoded;charset=UTF-8");
            request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);

            _restClient.Authenticator = new HttpBasicAuthenticator(_socialMediaAccount.AppKey,
                _socialMediaAccount.AppSecret);
            var response = _restClient.Execute<AccessTokenResponse>(request);
            return response.Handle();
        }

        public int GetPopularityCount(string userId, string accessToken)
        {
            var request = new RestRequest("/1.1/users/lookup.json", Method.GET);
            request.AddQueryParameter("screen_name", userId);
            _restClient.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(accessToken, "Bearer");
            var response = _restClient.Execute<List<FollowersCountReponse>>(request);
            return response.Handle().First().FollowersCount;
        }
    }
}

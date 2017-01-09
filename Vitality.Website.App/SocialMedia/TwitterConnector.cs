using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using RestSharp;
using Vitality.Website.App.Handlers;
using Vitality.Website.App.SocialMedia.Interfaces;
using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.App.SocialMedia.Models.Twitter;

namespace Vitality.Website.App.SocialMedia
{
    public class TwitterConnector : ITwitterConnector
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
            AddAuthHeader(ref request, GetAppKeyAndSecretAsBase64(), "Basic");
            request.AddHeader(HttpRequestHeader.ContentType.ToString(),
                "application/x-www-form-urlencoded;charset=UTF-8");
            request.AddParameter("grant_type", "client_credentials", ParameterType.GetOrPost);
            var response  = _restClient.Execute<AccessTokenResponse>(request);
            return response.Handle();
        }

        public FollowersCountReponse GetFollowersCount(string userId, string accessToken)
        {
            var request = new RestRequest("/1.1/users/lookup.json", Method.GET);
            AddAuthHeader(ref request, accessToken);
            request.AddQueryParameter("screen_name", userId);
            var response =  _restClient.Execute<List<FollowersCountReponse>>(request);
            return response.Handle().First();
        }

        private string GetAppKeyAndSecretAsBase64()
        {
            var apiKeyandC = string.Format("{0}:{1}", Uri.EscapeDataString(_socialMediaAccount.AppKey),
                Uri.EscapeDataString(_socialMediaAccount.AppSecret));

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(apiKeyandC));
        }

        private void AddAuthHeader(ref RestRequest request, string authValue, string authType = "Bearer" )
        {
            request.AddHeader(HttpRequestHeader.Authorization.ToString(), string.Format("{0} {1}", authType, authValue));
        }
    }
}

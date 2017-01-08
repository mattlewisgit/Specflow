﻿using RestSharp;
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
            request.AddQueryParameter("client_id", _socialMediaAccount.AppKey);
            request.AddQueryParameter("client_secret", _socialMediaAccount.AppSecret);
            request.AddQueryParameter("grant_type", "client_credentials");
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

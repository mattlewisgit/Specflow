using RestSharp;
using Vitality.Website.App.Models.SocialMedia;
using Vitality.Website.App.SocialMedia.Interfaces;

namespace Vitality.Website.App.SocialMedia
{
    public class FacebookConnector :ISocialMediaConnector
    {
        private RestClient _restClient; 
        private SocialMediaAccount _socialMediaAccount;

        public FacebookConnector(SocialMediaAccount socialMediaAccount)
        {
            _socialMediaAccount = socialMediaAccount;
            _restClient = new RestClient("https://graph.facebook.com");
        }

        public string GetAccessToken()
        {
            var url = string.Format(@"/oauth/access_token?client_id={0}&client_secret={1}&grant_type={2}", _socialMediaAccount.ClientId, _socialMediaAccount.ClientSecret, _socialMediaAccount.GrantType);
            var request = new RestRequest(url, Method.GET);
            return _restClient.Execute(request).Content;
        }
    }
}

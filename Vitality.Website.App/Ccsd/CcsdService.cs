using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Deserializers;
using Vitality.Website.App.Ccsd.Interfaces;
using Vitality.Website.App.Ccsd.Models;
using Vitality.Website.App.Helpers;
using Vitality.Website.App.Interfaces;

namespace Vitality.Website.App.Ccsd
{
    public class CcsdService : ICcsdService
    {
        private const string ContentType = "application/json";
        private readonly IMockDataHelper _mockDataHelper;

        public CcsdService(IMockDataHelper mockDataHelper)
        {
            _mockDataHelper = mockDataHelper;
        }

        public List<Chapter> GetChapters(IFeedSettings feedSetting)
        {
            var restClient = new RestClient(feedSetting.FeedUrl)
            {
                Authenticator = new HttpBasicAuthenticator(feedSetting.Username, feedSetting.Password)
            };

            var request = new RestRequest(Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = ContentType; };
            var response = restClient.Execute<ExternalCcsd>(request);

            return string.IsNullOrEmpty(feedSetting.MockDataFile)
                ? response.HandleResponse().Chapters
                : response.HandleResponse(
                    () => _mockDataHelper.GetMockData<ExternalCcsd>(ContentType, feedSetting.MockDataFile)).Chapters;
        }
    }
}

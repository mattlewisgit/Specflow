using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Vitality.Website.App.Helpers;
using Vitality.Website.App.Interfaces;
using Vitality.Website.App.Vacancies.Interfaces;
using Vitality.Website.App.Vacancies.Models;

namespace Vitality.Website.App.Vacancies
{
    public class VacancyService :IVacancyService
    {
        private readonly IMockDataHelper _mockDataHelper;

        public VacancyService(IMockDataHelper mockDataHelper)
        {
            _mockDataHelper = mockDataHelper;
        }

        public List<Item> GetLatestVacancies(IFeedSettings feedSetting)
        {
            var restClient = new RestClient(feedSetting.FeedUrl)
            {
                Authenticator = new HttpBasicAuthenticator(feedSetting.Username, feedSetting.Password)
            };
            var request = new RestRequest(Method.GET)
            {
                RequestFormat = DataFormat.Xml
            };
            var response = restClient.Execute<List<Item>>(request);

            return string.IsNullOrEmpty(feedSetting.MockDataFile) ?
                response.HandleResponse() :
                response.HandleResponse(() => _mockDataHelper.GetXmlMockData<List<Item>>(feedSetting.MockDataFile));
        }
    }
}

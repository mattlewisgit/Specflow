using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Vitality.Website.App.Helpers;
using Vitality.Website.App.Vacancies.Interfaces;
using Vitality.Website.App.Vacancies.Models;

namespace Vitality.Website.App.Vacancies
{
    public class VacancyService :IVacancyService
    {
        private readonly FeedSetting _feedSetting;
        private readonly IMockDataHelper _mockDataHelper;

        public VacancyService(FeedSetting feedSetting, IMockDataHelper mockDataHelper)
        {
            _feedSetting = feedSetting;
            _mockDataHelper = mockDataHelper;
        }

        public List<Vacancy> GetLatestVacancies()
        {
            var restClient = new RestClient(_feedSetting.Url)
            {
                Authenticator = new HttpBasicAuthenticator(_feedSetting.Username, _feedSetting.Password)
            };
            var request = new RestRequest(Method.GET)
            {
                RequestFormat = DataFormat.Xml
            };
            var response = restClient.Execute<VacancyFeed>(request);

            return string.IsNullOrEmpty(_feedSetting.MockDataFile) ?
                response.HandleResponse().Channel.Vacancies :
                response.HandleResponse(() => _mockDataHelper.GetXmlMockData<VacancyFeed>(_feedSetting.MockDataFile)).Channel.Vacancies;
        }
    }
}

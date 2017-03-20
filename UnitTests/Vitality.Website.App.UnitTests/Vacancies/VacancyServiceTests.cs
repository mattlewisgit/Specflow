using System.Collections.Generic;
using Moq;
using Shouldly;
using Vitality.Website.App.Helpers;
using Vitality.Website.App.Vacancies;
using Vitality.Website.App.Vacancies.Models;
using Xunit;

namespace Vitality.Website.App.UnitTests.Vacancies
{
    public class VacancyServiceTests
    {
        public class GetLatestVacancies
        {
            private readonly FeedSetting _feedSetting;
            private readonly Mock<IMockDataHelper> _mockedMockDataHelper;
            private VacancyService _vacancyService;

            public GetLatestVacancies()
            {
                _mockedMockDataHelper = new Mock<IMockDataHelper>();
                _feedSetting = new FeedSetting
                {
                    Password = "qp!Yg@J(A5gy/>S3",
                    Url = "https://postingpanda.com/feeds/yourboard",
                    Username = "vitalityfeed@postingpanda.com"
                };
            }

            [Fact]
            public void Should_return_vacancy_channel_when_passing_correct_url()
            {
                _vacancyService = new VacancyService(_feedSetting, _mockedMockDataHelper.Object);
                var response =
                    _vacancyService.GetLatestVacancies();
                response.Count.ShouldBeGreaterThan(0);
            }

            [Fact]
            public void Should_first_try_to_get_data_from_feed_even_if_mock_data_file_available()
            {
                _feedSetting.MockDataFile = "mockdataFile";
                _mockedMockDataHelper.Setup(m => m.GetXmlMockData<List<Item>>(_feedSetting.MockDataFile)).Returns(
                    new List<Item>
                    {
                        new Item()
                    });
                _vacancyService = new VacancyService(_feedSetting, _mockedMockDataHelper.Object);
                var response =
                    _vacancyService.GetLatestVacancies();
                response.Count.ShouldBeGreaterThan(0);
                _mockedMockDataHelper.Verify(m=>m.GetXmlMockData<List<Item>>(_feedSetting.MockDataFile),Times.Never);
            }
        }
    }
}

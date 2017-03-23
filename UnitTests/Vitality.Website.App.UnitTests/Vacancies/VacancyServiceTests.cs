using System.Collections.Generic;
using Moq;
using RestSharp.Deserializers;
using Shouldly;
using Vitality.Website.App.Helpers;
using Vitality.Website.App.Interfaces;
using Vitality.Website.App.Vacancies;
using Vitality.Website.App.Vacancies.Models;
using Xunit;

namespace Vitality.Website.App.UnitTests.Vacancies
{
    public class VacancyServiceTests
    {
        public class GetLatestVacancies
        {
            private readonly IFeedSettings _feedSettings;
            private readonly Mock<IMockDataHelper> _mockedMockDataHelper;
            private VacancyService _vacancyService;

            public GetLatestVacancies()
            {
                _mockedMockDataHelper = new Mock<IMockDataHelper>();
                var mockFeed = new Mock<IFeedSettings>();
                mockFeed.Setup(f => f.Password).Returns("qp!Yg@J(A5gy/>S3");
                mockFeed.Setup(f => f.FeedUrl).Returns("https://postingpanda.com/feeds/yourboard");
                mockFeed.Setup(f => f.Username).Returns("vitalityfeed@postingpanda.com");
                _feedSettings = mockFeed.Object;
            }

            [Fact]
            public void Should_return_vacancy_channel_when_passing_correct_url()
            {
                _vacancyService = new VacancyService(_mockedMockDataHelper.Object);
                var response =
                    _vacancyService.GetLatestVacancies(_feedSettings);
                response.Count.ShouldBeGreaterThan(0);
            }

            [Fact]
            public void Should_first_try_to_get_data_from_feed_even_if_mock_data_file_available()
            {
                _feedSettings.MockDataFile = "mockdataFile";
                _mockedMockDataHelper.Setup(m => m.GetMockData<List<Item>>(new XmlDeserializer(),  _feedSettings.MockDataFile)).Returns(
                    new List<Item>
                    {
                        new Item()
                    });
                _vacancyService = new VacancyService(_mockedMockDataHelper.Object);
                var response =
                    _vacancyService.GetLatestVacancies(_feedSettings);
                response.Count.ShouldBeGreaterThan(0);
                _mockedMockDataHelper.Verify(m=>m.GetMockData<List<Item>>(It.IsAny<XmlDeserializer>(), _feedSettings.MockDataFile),Times.Never);
            }
        }
    }
}

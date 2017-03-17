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
                response.GetType().ShouldBe(typeof(VacancyFeed));
            }
        }
    }
}

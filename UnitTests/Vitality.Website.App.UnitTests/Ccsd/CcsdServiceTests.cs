using System.Collections.Generic;
using Moq;
using RestSharp.Deserializers;
using Shouldly;
using Vitality.Website.App.Ccsd;
using Vitality.Website.App.Ccsd.Models;
using Vitality.Website.App.Helpers;
using Vitality.Website.App.Interfaces;
using Xunit;

namespace Vitality.Website.App.UnitTests.Ccsd
{
    public class CcsdServiceTests
    {
        public class GetChapters
        {
            private readonly IFeedSettings _feedSettings;
            private readonly Mock<IMockDataHelper> _mockedMockDataHelper;
            private CcsdService _ccsdService;

            public GetChapters()
            {
                _mockedMockDataHelper = new Mock<IMockDataHelper>();
                var mockFeed = new Mock<IFeedSettings>();
                mockFeed.Setup(f => f.Password).Returns("Kxfbxssoo320");
                mockFeed.Setup(f => f.FeedUrl).Returns("http://172.27.30.48:8380/Papillon/Service/EnterpriseCCSDPrice/");
                mockFeed.Setup(f => f.Username).Returns("tibco");
                mockFeed.Setup(f => f.MockDataFile).Returns("mockdatafile");
                _feedSettings = mockFeed.Object;
            }

            [Fact(Skip="TIBCO can't be connected locally")]
            public void Should_return_chapters_when_passing_correct_url()
            {
                _ccsdService = new CcsdService(_mockedMockDataHelper.Object);
                var response =
                    _ccsdService.GetChapters(_feedSettings);
                response.Count.ShouldBeGreaterThan(0);
            }

            [Fact(Skip="To fix")]
            public void Should_read_from_mock_data_file_when_end_point_throws_an_error()
            {
                _mockedMockDataHelper.Setup(
                        m => m.GetMockData<ExternalCcsd>(It.IsAny<JsonDeserializer>(), _feedSettings.MockDataFile))
                    .Returns(new ExternalCcsd
                    {
                        Chapters = new List<Chapter>
                            {
                                new Chapter()
                            }
                    });
                _ccsdService = new CcsdService(_mockedMockDataHelper.Object);
                var response = _ccsdService.GetChapters(_feedSettings);
                response.Count.ShouldBeGreaterThan(0);
                _mockedMockDataHelper.Verify(m => m.GetMockData<ExternalCcsd>(It.IsAny<JsonDeserializer>(), _feedSettings.MockDataFile), Times.Once);
            }
        }
    }
}

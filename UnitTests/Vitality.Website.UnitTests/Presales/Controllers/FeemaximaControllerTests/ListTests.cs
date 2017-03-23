using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Glass.Mapper.Sc;
using Moq;
using Shouldly;
using Vitality.Website.App.Ccsd.Interfaces;
using Vitality.Website.App.Ccsd.Models;
using Vitality.Website.Areas.Presales.Controllers;
using Vitality.Website.Areas.Presales.Handlers.FeeMaxima;
using Vitality.Website.Areas.Presales.SettingsTemplates;
using Vitality.Website.UnitTests.TestDoubles;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Controllers.FeemaximaControllerTests
{
    public class ListTests
    {
        private FeeMaximaController _controller;
        private readonly Guid _feedSettingId;
        private readonly Mock<ISitecoreContext> _sitecoreContext;
        private readonly Mock<ICcsdService> _ccsdService;


        public ListTests()
        {
            _feedSettingId = Guid.NewGuid();
            _sitecoreContext = new Mock<ISitecoreContext>();
            _ccsdService = new Mock<ICcsdService>();
        }

        [Fact]
        public void Should_respond_404_not_found_when_no_chapters_available()
        {
            _ccsdService.Setup(v => v.GetChapters(It.IsAny<FeedSettings>())).Returns(new List<Chapter>());
            Init();
            _controller.List(_feedSettingId).StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact]
        public void Should_respond_200_ok_when_chapters_returned()
        {
            _ccsdService.Setup(c => c.GetChapters(It.IsAny<FeedSettings>())).Returns(new List<Chapter>
            {
                new Chapter {Id = 1}
            });
            Init();
            _controller.List(_feedSettingId).StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public void Should_contain_chapters_in_the_response_body()
        {
            _ccsdService.Setup(c => c.GetChapters(It.IsAny<FeedSettings>())).Returns(new List<Chapter>
            {
                new Chapter {Id = 1}
            });
            Init();
            _controller.List(_feedSettingId)
                .Content.ReadAsAsync<FeeMaximaChaptersDto>()
                .Result.ShouldNotBeNull();
        }

        private void Init()
        {
            _sitecoreContext.Setup(m => m.GetItem<FeedSettings>(_feedSettingId, false, false))
                .Returns(new FeedSettings {Id = _feedSettingId});
            var handler =
                new MediatorStub<FeeMaximaChaptersRequest, FeeMaximaChaptersDto>(
                    new FeeMaximaChaptersHandler(_ccsdService.Object, _sitecoreContext.Object));
            _controller = new FeeMaximaController(handler);
        }
    }
}

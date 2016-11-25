using System.Net;
using System.Net.Http;

using Shouldly;

using Vitality.Website.Areas.Presales.Controllers;
using Vitality.Website.Areas.Presales.Handlers.Literature;
using Vitality.Website.UnitTests.TestDoubles;

using Xunit;
using Vitality.Website.Areas.Presales.Handlers.Feemaxima;
using System.Collections.Generic;
using Moq;
using Vitality.Website.App.Services.Interfaces;
using Vitality.Website.App.Models.Feemaxima;

namespace Vitality.Website.UnitTests.Presales.Controllers.FeemaximaControllerTests
{
    public class ListTests
    {
        private FeemaximaController _controller;

        private readonly Mock<ICcsdService> _ccsdService;

        public ListTests()
        {
            _ccsdService = new Mock<ICcsdService>();
        }

        [Fact]
        public void Should_respond_404_not_found_when_no_chapters_available()
        {
            Init();
            this._controller.List().StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact]
        public void Should_respond_200_ok_when_chapters_returned()
        {
            _ccsdService.Setup(c => c.GetChapters()).Returns(new List<Chapter>
            {
                new Chapter { Code ="10DS", Name="ABDOMEN" }
            });
            Init();
            this._controller.List().StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public void Should_contain_chapters_in_the_response_body()
        {
            _ccsdService.Setup(c => c.GetChapters()).Returns(new List<Chapter>
            {
                new Chapter { Code ="10DS", Name="ABDOMEN" }
            });
            Init();
            this._controller.List().Content.ReadAsAsync<FeemaximaChaptersDto>().Result.ShouldNotBeNull();
        }

        private void Init()
        {
            var handler = new MediatorStub<FeemaximaChaptersRequest, FeemaximaChaptersDto>(new FeemaximaChaptersHandler(_ccsdService.Object));
            this._controller = new FeemaximaController(handler);
        }
    }
}
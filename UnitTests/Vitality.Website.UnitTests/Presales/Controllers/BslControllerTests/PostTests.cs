using System.Net;
using Moq;
using Shouldly;
using Vitality.Website.Areas.Presales.Controllers;
using Vitality.Website.Areas.Presales.Handlers.Bsl;
using Vitality.Website.Areas.Presales.Services;
using Vitality.Website.UnitTests.TestDoubles;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Controllers.BslControllerTests
{
    public class PostTests
    {
        private BslController _controller;
        private readonly Mock<IPresalesBslService> _presalesBslService;
        private string _sampleJson = "{\"key\":\"value\"}";
        public PostTests()
        {
            _presalesBslService = new Mock<IPresalesBslService>();

        }

        [Fact]
        public async void Should_return_400_bad_request_when_end_point_is_not_provided()
        {
            Init();
            var result = await _controller.Post(null,It.IsAny<object>());
            result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Should_return_400_bad_request_when_post_data_is_not_provided()
        {
            Init();
            var result = await _controller.Post(It.IsAny<string>(), null);
            result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Should_return_400_bad_request_when_endpoint_or_post_data_is_not_provided()
        {
            Init();
            var result = await _controller.Post(null, null);
            result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Should_return_200ok_when_data_returned_from_presales_api()
        {
            _presalesBslService.Setup(p => p.Post<string>(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(_sampleJson);
            Init();
            var result = await _controller.Post("test", "mockfile");
            result.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        private void Init()
        {
            var handler =
               new MediatorAsyncStub<BslPostRequest, BslDto>(
                   new BslPostHandler(_presalesBslService.Object));
            _controller = new BslController(handler);
        }
    }
}

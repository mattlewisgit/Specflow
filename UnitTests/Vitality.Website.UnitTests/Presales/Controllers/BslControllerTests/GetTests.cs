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
    public class GetTests
    {
        private  BslController _controller;
        private  readonly Mock<IPresalesBslService> _presalesBslService;
        private string _sampleJson = "{\"key\":\"value\"}";
        public GetTests()
        {
            _presalesBslService = new Mock<IPresalesBslService>();

        }

        [Fact]
        public async void Should_return_400_bad_request_when_end_point_is_not_provided()
        {
            Init();
            var result = await   _controller.Get(null);
            result.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void Should_return_200ok_when_data_returned_from_presales_api()
        {
            _presalesBslService.Setup(p => p.Get<string>(It.IsAny<string>())).ReturnsAsync(_sampleJson);
            Init();
           var result = await  _controller.Get("test");
            result.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        private void Init()
        {
            var handler =
               new MediatorAsyncStub<BslGetRequest, BslDto>(
                   new BslGetHandler(_presalesBslService.Object));
            _controller = new BslController(handler);
        }
    }
}

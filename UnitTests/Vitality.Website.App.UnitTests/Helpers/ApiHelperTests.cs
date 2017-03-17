using System;
using System.Net;
using Moq;
using RestSharp;
using Shouldly;
using Vitality.Website.App.Helpers;
using Xunit;

namespace Vitality.Website.App.UnitTests.Helpers
{
    public class ApiHandlerTests
    {
        public class HandleResponse
        {
            private readonly Mock<IRestResponse<string>> _mockRestResponse;

            public HandleResponse()
            {
                _mockRestResponse = new Mock<IRestResponse<string>>();
            }

            [Fact]
            public void When_status_code_is_ok_returns_data()
            {
                var responseData = "Test Response Data";
                _mockRestResponse.Setup(r => r.StatusCode).Returns(HttpStatusCode.OK);
                _mockRestResponse.Setup(r => r.Data).Returns(responseData);
                _mockRestResponse.Object.HandleResponse().ShouldBe(responseData);
            }

            [Fact]
            public void When_status_code_is_not_ok_throws_an_exception_with_error_detaiils()
            {
                var errorMessage = "Not Found Error Occured";
                _mockRestResponse.Setup(r => r.StatusCode).Returns(HttpStatusCode.NotFound);
                _mockRestResponse.Setup(r => r.Content).Returns(errorMessage);
                var exception = Assert.Throws<Exception>(() => _mockRestResponse.Object.HandleResponse());
                exception.Data[ApiHelper.StatusCodeKey] = 404;
                exception.Data[ApiHelper.MoreInfoKey] = errorMessage;
            }

            [Fact]
            public void When_status_code_is_not_ok_but_pass_get_mock_data_function_returns_data_from_mock_data_file()
            {
                var mockDataHelper = new Mock<IMockDataHelper>();
                _mockRestResponse.Setup(r => r.StatusCode).Returns(HttpStatusCode.NotFound);
                _mockRestResponse.Object.HandleResponse(() => mockDataHelper.Object.GetXmlMockData<string>("testMockDataFile"));
                mockDataHelper.Verify(m=>m.GetXmlMockData<string>(It.IsAny<string>()),Times.Once);
            }
        }
    }
}

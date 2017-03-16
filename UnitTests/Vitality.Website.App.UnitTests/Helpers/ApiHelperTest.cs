﻿using System;
using System.Net;
using Moq;
using RestSharp;
using Shouldly;
using Vitality.Website.App.Helpers;
using Xunit;

namespace Vitality.Website.App.UnitTests.Helpers
{
    public class ApiHandlerTest
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
        }
    }
}

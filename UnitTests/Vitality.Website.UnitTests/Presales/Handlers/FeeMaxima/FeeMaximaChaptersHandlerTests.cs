using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using Shouldly;
using Vitality.Website.App.Models.FeeMaxima;
using Vitality.Website.App.Services.Interfaces;
using Vitality.Website.Areas.Presales.Handlers.FeeMaxima;
using Vitality.Website.Areas.Presales.Handlers.Literature;
using Vitality.Website.UnitTests.TestDoubles;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.FeeMaxima
{
    public class FeeMaximaChaptersHandlerTests
    {
        private readonly FeeMaximaChaptersHandler handler;
        private readonly Mock<ICcsdService> _ccsdServiceMock;

        public FeeMaximaChaptersHandlerTests()
        {
            _ccsdServiceMock = new Mock<ICcsdService>();
            this.handler = new FeeMaximaChaptersHandler(_ccsdServiceMock.Object);
        }

        [Fact]
        public void Should_return_FeeMaximaChaptersDto_object_with_chapters_when_service_returns_chapters()
        {
            _ccsdServiceMock.Setup(c => c.GetChapters()).Returns(new List<Chapter> {new Chapter {Id=1} });
            var result = this.handler.Handle(new FeeMaximaChaptersRequest());
            result.ShouldBeOfType(typeof(FeeMaximaChaptersDto));
            result.Chapters.Count().ShouldBe(1);
        }
    }
}

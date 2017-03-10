using System.Collections.Generic;
using System.Linq;

using Moq;
using Shouldly;
using Vitality.Website.App.Ccsd.Interfaces;
using Vitality.Website.App.Ccsd.Models;
using Vitality.Website.Areas.Presales.Handlers.FeeMaxima;

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

        [Fact(Skip="Fix it")]
        public void Should_return_FeeMaximaChaptersDto_object_with_chapters_when_service_returns_chapters()
        {
            _ccsdServiceMock.Setup(c => c.GetChapters(It.IsAny<string>())).Returns(new List<Chapter> {new Chapter {Id=1} });
            var result = this.handler.Handle(new FeeMaximaChaptersRequest());
            result.ShouldBeOfType(typeof(FeeMaximaChaptersDto));
            result.Chapters.Count().ShouldBe(1);
        }
    }
}

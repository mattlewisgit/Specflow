using Shouldly;
using System.Collections.Generic;
using Vitality.Website.App.Models.FeeMaxima;
using Vitality.Website.App.Services;
using Xunit;

namespace Vitality.Website.App.UnitTests.Services
{
    public class CcsdServiceTests
    {
        private static CcsdService _ccsdService;

        public class GetChaptersTests
        {
            public GetChaptersTests()
            {
                _ccsdService = new CcsdService();
            }

            [Fact]
            public void GetChapters_should_returns_list_of_chapters()
            {
                _ccsdService.GetChapters().ShouldBeOfType(typeof(List<Chapter>));
            }
        }
    }
}

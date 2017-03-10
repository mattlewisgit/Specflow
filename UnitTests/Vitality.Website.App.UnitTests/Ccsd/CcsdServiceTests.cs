using Shouldly;
using System.Collections.Generic;
using Vitality.Website.App.Ccsd;
using Vitality.Website.App.Ccsd.Models;
using Xunit;

namespace Vitality.Website.App.UnitTests.Ccsd
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

            [Fact(Skip = "Hardcoded JSON reference")]
            public void GetChapters_should_returns_list_of_chapters()
            {
                _ccsdService.GetChapters(@"C:\projects\vitality-website\Vitality.Website.App\Data\CcsdChaptersWithProcedures.json").ShouldBeOfType(typeof(List<Chapter>));
            }
        }
    }
}

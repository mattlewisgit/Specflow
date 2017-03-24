using System;
using Shouldly;
using Vitality.Website.Areas.Presales.Handlers.FeeMaxima;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.FeeMaxima
{
    public class FeeMaximaChaptersRequestTests
    {
        [Fact]
        public void new_instance_should_assign_all_property_values()
        {
            var settingsId = Guid.NewGuid();
            var result = new FeeMaximaChaptersRequest(settingsId);
            result.SettingsId.ShouldBe(settingsId);
        }
    }
}

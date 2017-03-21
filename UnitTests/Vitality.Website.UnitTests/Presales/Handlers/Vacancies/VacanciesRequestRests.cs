using System;
using Shouldly;
using Vitality.Website.Areas.Presales.Handlers.Vacancies;
using Vitality.Website.Areas.Presales.SettingsTemplates;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.Vacancies
{
    public class VacanciesRequestRests
    {
        [Fact]
        public void new_instance_should_assign_all_property_values()
        {
            var settingsId = Guid.NewGuid();
            var result = new VacanciesRequest(settingsId);
            result.SettingsId.ShouldBe(settingsId);
        }
    }
}

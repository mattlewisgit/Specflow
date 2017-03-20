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
            var result = new VacanciesRequest(new FeedSettings());
            result.FeedSettings.ShouldNotBeNull();
        }
    }
}

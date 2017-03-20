using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Vitality.Website.App.Vacancies.Models;
using Vitality.Website.Areas.Presales.Handlers.SocialMedia;
using Vitality.Website.Areas.Presales.Handlers.Vacancies;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.Vacancies
{
    public class VacanciesDtoTests
    {
        public class From
        {
            [Fact]
            public void should_assign_counts_property()
            {
                VacanciesDto.From(new List<Item> {new Item()}).Vacancies.Count().ShouldBe(1);
            }
        }
    }
}

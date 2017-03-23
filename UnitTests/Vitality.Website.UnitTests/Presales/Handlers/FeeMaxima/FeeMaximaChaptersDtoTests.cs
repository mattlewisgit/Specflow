using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Vitality.Website.App.Ccsd.Models;
using Vitality.Website.Areas.Presales.Handlers.FeeMaxima;
using Vitality.Website.Areas.Presales.Handlers.Vacancies;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.FeeMaxima
{
    public class FeeMaximaChaptersDtoTests
    {
        public class From
        {
            [Fact]
            public void should_assign_vacancies()
            {
                FeeMaximaChaptersDto.From(new List<Chapter> { new Chapter() }).Chapters.Count().ShouldBe(1);
            }
        }
    }
}

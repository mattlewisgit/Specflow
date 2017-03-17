using System.Collections.Generic;
using Vitality.Website.App.Helpers;
using Vitality.Website.App.Vacancies.Models;

namespace Vitality.Website.App.Vacancies.Interfaces
{
    public interface IVacancyService
    {
        List<Vacancy> GetLatestVacancies();
    }
}

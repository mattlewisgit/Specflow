using System.Collections.Generic;
using Vitality.Website.App.Vacancies.Models;

namespace Vitality.Website.App.Vacancies.Interfaces
{
    public interface IVacancyService
    {
        IEnumerable<Vacancy> GetLatestVacancies(string url);
    }
}

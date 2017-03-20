using System.Collections.Generic;
using Vitality.Website.App.Vacancies.Models;

namespace Vitality.Website.App.Vacancies.Interfaces
{
    public interface IVacancyService
    {
        List<Item> GetLatestVacancies();
    }
}

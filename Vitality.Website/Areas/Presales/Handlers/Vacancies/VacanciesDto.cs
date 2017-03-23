using System.Collections.Generic;
using Vitality.Website.App.Vacancies.Models;

namespace Vitality.Website.Areas.Presales.Handlers.Vacancies
{
    public class VacanciesDto
    {
        public IEnumerable<Item> Vacancies { get; set; }

        public static VacanciesDto From(IEnumerable<Item> vacancies)
        {
            return new VacanciesDto
            {
                Vacancies = vacancies
            };
        }
    }
}

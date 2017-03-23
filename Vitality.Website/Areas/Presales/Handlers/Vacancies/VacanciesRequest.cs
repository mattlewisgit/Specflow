using System;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Vacancies
{
    public class VacanciesRequest : IRequest<VacanciesDto>
    {
        public readonly Guid SettingsId;
        public VacanciesRequest(Guid settingsId)
        {
            SettingsId = settingsId;
        }
    }
}

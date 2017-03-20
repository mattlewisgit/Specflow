using MediatR;
using Vitality.Website.App.Interfaces;
using Vitality.Website.Areas.Presales.SettingsTemplates;

namespace Vitality.Website.Areas.Presales.Handlers.Vacancies
{
    public class VacanciesRequest : IRequest<VacanciesDto>
    {
        public readonly FeedSettings FeedSettings;
        public VacanciesRequest(FeedSettings feedSettings)
        {
            FeedSettings = feedSettings;
        }
    }
}

using System;
using System.Runtime.Caching;
using System.Web;
using Glass.Mapper.Sc;
using MediatR;
using Vitality.Website.App.Vacancies.Interfaces;
using Vitality.Website.Areas.Presales.SettingsTemplates;
using Vitality.Website.Extensions;

namespace Vitality.Website.Areas.Presales.Handlers.Vacancies
{
    public class VacanciesHandler : IRequestHandler<VacanciesRequest, VacanciesDto>
    {
        private static readonly ObjectCache MemoryCacheStore = MemoryCache.Default;
        private readonly ISitecoreContext _sitecoreContext;
        private readonly IVacancyService _vacancyService;

        public VacanciesHandler(ISitecoreContext sitecoreContext, IVacancyService vacancyService)
        {
            _sitecoreContext = sitecoreContext;
            _vacancyService = vacancyService;
        }

        public VacanciesDto Handle(VacanciesRequest request)
        {
            return MemoryCacheStore.AddOrGet(string.Format("{0}_vacancies", request.SettingsId),
                () => CallVacancyService(request),
                DateTimeOffset.UtcNow.AddHours(1));
        }

        public VacanciesDto CallVacancyService(VacanciesRequest request)
        {
            var feedSettings = _sitecoreContext.GetItem<FeedSettings>(request.SettingsId);
            if (feedSettings != null && !string.IsNullOrEmpty(feedSettings.MockDataFile))
            {
                feedSettings.MockDataFile = HttpContext.Current.Server.MapPath(feedSettings.MockDataFile);
            }
            return VacanciesDto.From(_vacancyService.GetLatestVacancies(feedSettings));
        }
    }
}

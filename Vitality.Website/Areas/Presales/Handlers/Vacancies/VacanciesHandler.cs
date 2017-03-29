namespace Vitality.Website.Areas.Presales.Handlers.Vacancies
{
    using System;
    using System.Runtime.Caching;
    using System.Web;
    using Glass.Mapper.Sc;
    using MediatR;
    using App.Vacancies.Interfaces;
    using SettingsTemplates;
    using Core;

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

        public VacanciesDto Handle(VacanciesRequest request) =>
            MemoryCacheStore.AddOrGet(
                $"{request.SettingsId}_vacancies",
                () => CallVacancyService(request),
                DateTimeOffset.UtcNow.AddHours(1));

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

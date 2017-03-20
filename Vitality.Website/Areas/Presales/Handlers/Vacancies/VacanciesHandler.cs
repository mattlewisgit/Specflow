using System;
using System.Runtime.Caching;
using MediatR;
using Vitality.Website.App.Vacancies.Interfaces;
using Vitality.Website.Extensions;

namespace Vitality.Website.Areas.Presales.Handlers.Vacancies
{
    public class VacanciesHandler : IRequestHandler<VacanciesRequest, VacanciesDto>
    {
        private static readonly ObjectCache MemoryCacheStore = MemoryCache.Default;

        private readonly IVacancyService _vacancyService;

        public VacanciesHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public VacanciesDto Handle(VacanciesRequest request)
        {
            return MemoryCacheStore.AddOrGet(string.Format("{0}_vacancies", request.FeedSettings.Id),
                () => CallVacancyService(request),
                DateTimeOffset.UtcNow.AddHours(1));
        }

        public VacanciesDto CallVacancyService(VacanciesRequest request)
        {
            return VacanciesDto.From(_vacancyService.GetLatestVacancies(request.FeedSettings));
        }
    }
}

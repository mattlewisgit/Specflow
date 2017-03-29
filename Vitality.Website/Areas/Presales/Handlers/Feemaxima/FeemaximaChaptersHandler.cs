namespace Vitality.Website.Areas.Presales.Handlers.FeeMaxima
{
    using System;
    using System.Runtime.Caching;
    using System.Web;
    using Glass.Mapper.Sc;
    using MediatR;
    using App.Ccsd.Interfaces;
    using SettingsTemplates;
    using Core;

    public class FeeMaximaChaptersHandler : IRequestHandler<FeeMaximaChaptersRequest, FeeMaximaChaptersDto>
    {
        private static readonly ObjectCache MemoryCacheStore = MemoryCache.Default;
        private readonly ICcsdService _ccsdService;
        private readonly ISitecoreContext _sitecoreContext;

        public FeeMaximaChaptersHandler(ICcsdService ccsdService, ISitecoreContext sitecoreContext)
        {
            _ccsdService = ccsdService;
            _sitecoreContext = sitecoreContext;
        }

        public FeeMaximaChaptersDto Handle(FeeMaximaChaptersRequest request) =>
            MemoryCacheStore.AddOrGet(
                $"{request.SettingsId}_ccsdchapters",
                () => CallCcsdService(request),
                DateTimeOffset.UtcNow.AddDays(1));

        public FeeMaximaChaptersDto CallCcsdService(FeeMaximaChaptersRequest request)
        {
            var feedSettings = _sitecoreContext.GetItem<FeedSettings>(request.SettingsId);

            if (feedSettings != null && !string.IsNullOrEmpty(feedSettings.MockDataFile))
            {
                feedSettings.MockDataFile = HttpContext.Current.Server.MapPath(feedSettings.MockDataFile);
            }

            return FeeMaximaChaptersDto.From(_ccsdService.GetChapters(feedSettings));
        }
    }
}

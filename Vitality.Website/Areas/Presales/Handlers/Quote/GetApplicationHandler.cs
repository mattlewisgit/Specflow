using System.Runtime.Caching;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Quote
{
    public class GetApplicationHandler : IRequestHandler<GetApplicationRequest, object>
    {
        private static readonly ObjectCache MemoryCacheStore = MemoryCache.Default;

        public object Handle(GetApplicationRequest request) =>
            MemoryCacheStore.Get(request.ApplicationId);
    }
}

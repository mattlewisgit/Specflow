using System;
using System.Runtime.Caching;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.Quote
{
    public class SaveApplicationHandler : IRequestHandler<SaveApplicationRequest, string>
    {
        private static readonly ObjectCache MemoryCacheStore = MemoryCache.Default;

        //Don't use the mMemory Cache use database going foward, Story to add the DB is not yet in a sprint
        public string Handle(SaveApplicationRequest request)
        {
            if (string.IsNullOrEmpty(request.ReferenceId))
            {
                request.ReferenceId = Guid.NewGuid().ToString();
            }
            MemoryCacheStore.Add(request.ReferenceId, request.Application, DateTimeOffset.UtcNow.AddHours(1));
            return request.ReferenceId;
        }
    }
}

using MediatR;
using System.Threading.Tasks;
using Vitality.Website.Areas.Presales.Services;

namespace Vitality.Website.Areas.Presales.Handlers.Bsl
{
    public class BslGetHandler : IAsyncRequestHandler<BslGetRequest, BslDto>
    {
        private readonly IPresalesBslService _presalesBslService;

        public BslGetHandler(IPresalesBslService presalesBslService)
        {
            _presalesBslService = presalesBslService;
        }

        public async Task<BslDto> Handle(BslGetRequest request) =>
            await BslDto.From(_presalesBslService.Get<string>(request.BslEndpoint));
    }
}

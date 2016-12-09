using MediatR;
using Vitality.Website.App.Services.Interfaces;

namespace Vitality.Website.Areas.Presales.Handlers.FeeMaxima
{
    public class FeeMaximaChaptersHandler : IRequestHandler<FeeMaximaChaptersRequest, FeeMaximaChaptersDto>
    {
        private readonly ICcsdService _ccsdService;

        public FeeMaximaChaptersHandler(ICcsdService ccsdService)
        {
            _ccsdService = ccsdService;
        }

        public FeeMaximaChaptersDto Handle(FeeMaximaChaptersRequest request)
        {
            return FeeMaximaChaptersDto.From(_ccsdService.GetChapters());
        }
    }
}

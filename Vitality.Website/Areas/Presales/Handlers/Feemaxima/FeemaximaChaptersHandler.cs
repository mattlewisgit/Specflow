using MediatR;
using Vitality.Website.App.Services.Interfaces;

namespace Vitality.Website.Areas.Presales.Handlers.Feemaxima
{
    public class FeemaximaChaptersHandler : IRequestHandler<FeemaximaChaptersRequest, FeemaximaChaptersDto>
    {
        private readonly ICcsdService _ccsdService;

        public FeemaximaChaptersHandler(ICcsdService ccsdService)
        {
            _ccsdService = ccsdService;
        }

        public FeemaximaChaptersDto Handle(FeemaximaChaptersRequest request)
        {
            return FeemaximaChaptersDto.From(_ccsdService.GetChapters());
        }
    }
}
using System.Web;
using MediatR;
using Sitecore.ApplicationCenter.Applications;
using Vitality.Website.App.Ccsd.Interfaces;

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
            return FeeMaximaChaptersDto.From(_ccsdService.GetChapters(HttpContext.Current.Server.MapPath("~/App_Data/CcsdChaptersWithProcedures.json")));
        }
    }
}

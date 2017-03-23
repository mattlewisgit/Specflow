using System;
using MediatR;

using System.Linq;
using System.Net.Http;
using System.Web.Http;

using Vitality.Website.Areas.Presales.Handlers.FeeMaxima;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class FeeMaximaController : BaseController
    {
        public FeeMaximaController(IMediator mediator) :base(mediator) { }

        [HttpGet]
        [Route("api/Feemaxima/List")]
        public HttpResponseMessage List(Guid settingsId)
        {
            return GetResponse<FeeMaximaChaptersRequest, FeeMaximaChaptersDto>(
                new FeeMaximaChaptersRequest(settingsId), chapters=>chapters.Chapters.Any());
        }
    }
}

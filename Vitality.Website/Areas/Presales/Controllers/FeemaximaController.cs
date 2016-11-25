using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Vitality.Website.App.Models.FeeMaxima;
using Vitality.Website.Areas.Presales.Handlers.FeeMaxima;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class FeeMaximaController : BaseController
    {
        public FeeMaximaController(IMediator mediator):base(mediator)
        {
        }

        [Route("api/Feemaxima/List")]
        public HttpResponseMessage List()
        {
            return this.GetResponse<FeeMaximaChaptersRequest, FeeMaximaChaptersDto>(
                new FeeMaximaChaptersRequest(), chapters=>chapters.Chapters.Any());
        }
    }
}

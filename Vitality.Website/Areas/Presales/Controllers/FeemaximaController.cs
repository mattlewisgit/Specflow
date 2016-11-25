using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Vitality.Website.App.Models.Feemaxima;
using Vitality.Website.Areas.Presales.Handlers.Feemaxima;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class FeemaximaController : BaseController
    {
        public FeemaximaController(IMediator mediator):base(mediator)
        {
        }

        [Route("api/Feemaxima/List")]
        public HttpResponseMessage List()
        {
            return this.GetResponse<FeemaximaChaptersRequest, FeemaximaChaptersDto>(
                new FeemaximaChaptersRequest(), chapters=>chapters.Chapters.Any());
        }
    }
}

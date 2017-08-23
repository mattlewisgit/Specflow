using System.Net;
using MediatR;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using Vitality.Website.Areas.Presales.Models.QuoteApply;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class QuoteApplyController : BaseController
    {
        public QuoteApplyController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/rtpe/saveapplication")]
        public HttpResponseMessage SaveApplication(QuoteApplication application)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}

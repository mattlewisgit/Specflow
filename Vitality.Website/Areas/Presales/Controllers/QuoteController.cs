using System.Net.Http;
using System.Web.Http;
using MediatR;
using Vitality.Website.Areas.Presales.Handlers.Quote;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class QuoteController : BaseController
    {
        public QuoteController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/quote/saveapplication")]
        public HttpResponseMessage SaveApplication(object application, string referenceId)
        {
            return GetResponse<SaveApplicationRequest, string>(new SaveApplicationRequest(application, referenceId),
                refId =>
                        !string.IsNullOrEmpty(refId));
        }

        [HttpGet]
        [Route("api/quote/getapplication/{referenceId}")]
        public HttpResponseMessage GetApplication(string referenceId)
        {
            return GetResponse<GetApplicationRequest, object>(new GetApplicationRequest(referenceId),
                application => application != null);
        }
    }
}

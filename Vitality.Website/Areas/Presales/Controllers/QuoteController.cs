using System.Net.Http;
using System.Web.Http;
using MediatR;
using Vitality.Website.Areas.Presales.Handlers.Quote;
using Vitality.Website.Areas.Presales.Handlers.Bsl;
using Vitality.Mvc.Utilities;
using Newtonsoft.Json;
using Vitality.Website.Areas.Presales.Models;
using Vitality.Website.Areas.Presales.Services;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class QuoteController : BaseController
    {
        public QuoteController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/quote/saveapplication")]
        public HttpResponseMessage SaveApplication(SaveApplicationModel application, string referenceId)
        {
            var response = GetResponse<SaveApplicationRequest, string>(new SaveApplicationRequest(application, referenceId), refId => !string.IsNullOrEmpty(refId));

            var utmCookie = UtmCookieHelper.GetUtmCookie(new System.Web.HttpRequestWrapper(System.Web.HttpContext.Current.Request));
            var refIdTemp = response.Content.ReadAsStringAsync().Result;
            var optalitixRequest = OptalitixQuoteRequestFactory.From(application, utmCookie, refIdTemp);
            GetResponseAsync<BslPostRequest, BslDto>(new BslPostRequest("optalitix/createquote",
                JsonConvert.SerializeObject(new { FeedSettings = new object(), OptalitixQuoteRequest = optalitixRequest })), result => result != null);
            
            return response;
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

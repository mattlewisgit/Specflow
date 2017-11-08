using System.Net.Http;
using System.Threading.Tasks;
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
        [Route("api/quote/sendtooptalatix/{referenceNumber}")]
        public async Task<HttpResponseMessage> SendToOptalatix(string bslEndpoint, string referenceNumber, SaveApplicationModel application)
        {
            var response = GetResponse<SendToOptalatixRequest, string>(
                new SendToOptalatixRequest(application, referenceNumber), refId => !string.IsNullOrEmpty(refId));

            var utmCookie =
                UtmCookieHelper.GetUtmCookie(new System.Web.HttpRequestWrapper(System.Web.HttpContext.Current.Request));
            var refIdTemp =
                JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result ?? string.Empty);

            var optalitixRequest = OptalitixQuoteRequestFactory.From(application, utmCookie, refIdTemp);
            return await GetResponseAsync<BslPostRequest, BslDto>(new BslPostRequest("optalitix/createquote",
                JsonConvert.SerializeObject(new
                {
                    FeedSettings = new object(),
                    OptalitixQuoteRequest = optalitixRequest
                })), result => result != null);

        }
    }
}

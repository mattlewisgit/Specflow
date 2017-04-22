using MediatR;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Vitality.Website.Areas.Presales.Handlers.Bsl;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class BslController : BaseController
    {
        public BslController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("api/bsl/get")]
        public async Task<HttpResponseMessage> Get(string endpoint)
        {
            return await GetResponseAsync<BslGetRequest, BslDto>(
                new BslGetRequest(endpoint), result =>result !=null);
        }

        [HttpPost]
        [Route("api/bsl/post")]
        public async Task<HttpResponseMessage> Post(string endpoint, object postData)
        {
            return await GetResponseAsync<BslPostRequest, BslDto>(
                new BslPostRequest(endpoint, postData), result => result != null);
        }
    }
}

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


        /// <summary>
        /// Send Get request to Vitality.BSL.Presales Api and return response
        /// </summary>
        /// <param name="bslEndpoint">Endpoint with query string</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/bsl/get")]
        public async Task<HttpResponseMessage> Get(string bslEndpoint)
        {
            return await GetResponseAsync<BslGetRequest, BslDto>(
                new BslGetRequest(bslEndpoint), result =>result !=null);
        }

        /// <summary>
        /// Send Post request to Vitality.BSL.Presales Api and return response
        /// </summary>
        /// <param name="bslEndpoint">Endpoint</param>
        /// <param name="postData">Data to post to BSL</param>
        [HttpPost]
        [Route("api/bsl/post")]
        public async Task<HttpResponseMessage> Post(string bslEndpoint, object postData)
        {
            return await GetResponseAsync<BslPostRequest, BslDto>(
                new BslPostRequest(bslEndpoint, postData), result => result != null);
        }
    }
}

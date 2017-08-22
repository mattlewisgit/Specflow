using System.Net.Http;
using System.Threading.Tasks;

namespace Vitality.Website.Areas.Presales.Handlers.CallBack
{
    public class CallBackDto
    {
        public HttpResponseMessage CallBackResponse { get; set; }

        public string Reason { get; set; }

        public static async Task<CallBackDto> From(Task<HttpResponseMessage> bslResponse, string reason = "")
        {
            return new CallBackDto
            {
                CallBackResponse = await bslResponse,
                Reason = reason
            };
        }
    }
}
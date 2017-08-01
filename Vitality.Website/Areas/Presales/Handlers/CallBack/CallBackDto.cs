using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Vitality.Website.Areas.Presales.Handlers.CallBack
{
    public class CallBackDto
    {
        public HttpResponseMessage BslResponse { get; set; }

        public string Reason { get; set; }

        public static async Task<CallBackDto> From(Task<HttpResponseMessage> bslResponse, string reason = "")
        {
            return new CallBackDto
            {
                BslResponse = await bslResponse,
                Reason = reason
            };
        }
    }
}
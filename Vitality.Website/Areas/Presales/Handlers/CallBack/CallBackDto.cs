using System;
using System.Net;
using System.Net.Http;

namespace Vitality.Website.Areas.Presales.Handlers.CallBack
{
    public class CallBackDto
    {
        public HttpResponseMessage BslResponse { get; set; }

        public string Reason { get; set; }

        public static CallBackDto From(HttpResponseMessage bslResponse, string reason)
        {
            return new CallBackDto
            {
                BslResponse = bslResponse,
                Reason = reason
            };
        }
    }
}
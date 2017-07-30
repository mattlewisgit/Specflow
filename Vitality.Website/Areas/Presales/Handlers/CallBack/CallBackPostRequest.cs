using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.CallBack
{
    public class CallBackPostRequest : IRequest<CallBackDto>, IRequest<HttpResponseMessage>
    {
        public readonly Models.CallBack PostData;

        public CallBackPostRequest(Models.CallBack postData)
        {
            PostData = postData;
        }
    }
}
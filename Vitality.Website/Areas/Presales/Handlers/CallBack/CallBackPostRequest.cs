using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.CallBack
{
    public class CallBackPostRequest : IRequest<CallBackDto>
    {
        public readonly Models.CallBackData PostData;

        public CallBackPostRequest(){}

        public CallBackPostRequest(Models.CallBackData postData)
        {
            PostData = postData;
        }
    }
}
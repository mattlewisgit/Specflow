using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediatR;
using Vitality.Website.Areas.Presales.Handlers.CallBack;
using Vitality.Website.Areas.Presales.Handlers.ContentSearch;
using Vitality.Website.Areas.Presales.Models;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class CallBackController : BaseController
    {
        public CallBackController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/callback")]
        public HttpResponseMessage Post(CallBack model)
        {
            if (string.IsNullOrWhiteSpace(model.Firstname))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return GetResponse<CallBackPostRequest, CallBackDto>(new CallBackPostRequest(model), result => result != null);
        }
    } 
}

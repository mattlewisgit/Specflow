using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class BaseController : ApiController
    {
        private readonly IMediator mediator;
        public BaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected HttpResponseMessage GetResponse<TRequest, TResponse>(TRequest request, Predicate<TResponse> isValidResponse) where TRequest : IRequest<TResponse>
        {
            var response = this.mediator.Send(request);
            if (isValidResponse(response))
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<TResponse>(response, new JsonMediaTypeFormatter())
                };
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }
    }
}

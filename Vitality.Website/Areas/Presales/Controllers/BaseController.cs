using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class BaseController : ApiController
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected HttpResponseMessage GetResponse<TRequest, TResponse>(TRequest request,
            Predicate<TResponse> isValidResponse) where TRequest : IRequest<TResponse>
        {
            return HandleResponse(_mediator.Send(request), isValidResponse);
        }

        protected async Task<HttpResponseMessage> GetResponseAsync<TRequest, TResponse>(TRequest request,
            Predicate<TResponse> isValidResponse) where TRequest : IAsyncRequest<TResponse>
        {
            return HandleResponse(await _mediator.SendAsync(request), isValidResponse);
        }

        private HttpResponseMessage HandleResponse<TResponse>(TResponse response, Predicate<TResponse> isValidResponse)
        {
            if (isValidResponse(response))
            {
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<TResponse>(response, new JsonMediaTypeFormatter())
                };
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        }

        public HttpResponseMessage HandleBadRequest() =>
            new HttpResponseMessage(HttpStatusCode.BadRequest);
    }
}

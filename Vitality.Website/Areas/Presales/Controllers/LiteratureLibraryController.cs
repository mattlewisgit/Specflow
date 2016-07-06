namespace Vitality.Website.Areas.Presales.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Web.Http;

    using MediatR;

    using Vitality.Website.Areas.Presales.Handlers;

    public class LiteratureLibraryController : ApiController
    {
        private readonly IMediator mediator;

        public LiteratureLibraryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [Route("api/literature/{library}/{category}/{title}")]
        public HttpResponseMessage Get(string library, string category, string title, bool includeAvailableLiterature = false)
        {
            if (string.IsNullOrWhiteSpace(library) || string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(title))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return this.GetResponse<LiteratureDocumentRequest, LiteratureDocumentDto>(
                new LiteratureDocumentRequest(library, category, title, includeAvailableLiterature),
                document => document != null);
        }

        [HttpGet]
        [Route("api/literature/{library}/search")]
        public HttpResponseMessage Search(string library, [FromUri]string title)
        {
            if (string.IsNullOrWhiteSpace(library) || string.IsNullOrWhiteSpace(title))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);                
            }

            return this.GetResponse<LiteratureDocumentSummariesRequest, IEnumerable<LiteratureDocumentSummaryDto>>(
                new LiteratureDocumentSummariesRequest(library, title: title),
                documents => documents.Any());
        }

        [HttpGet]
        [Route("api/literature/{library}/{category}")]
        public HttpResponseMessage List(string library, string category)
        {
            if (string.IsNullOrWhiteSpace(library) || string.IsNullOrWhiteSpace(category))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return this.GetResponse<LiteratureDocumentSummariesRequest, IEnumerable<LiteratureDocumentSummaryDto>>(
                new LiteratureDocumentSummariesRequest(library, category),
                documents => documents.Any());
        }

        private HttpResponseMessage GetResponse<TRequest, TResponse>(TRequest request, Predicate<TResponse> isValidResponse) where TRequest : IRequest<TResponse>
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
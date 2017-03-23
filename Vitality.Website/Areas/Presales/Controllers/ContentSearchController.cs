using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MediatR;
using Vitality.Website.Areas.Presales.Handlers.ContentSearch;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class ContentSearchController : BaseController
    {
        public ContentSearchController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("api/search/")]
        public HttpResponseMessage Search(ContentSearchRequest model)
        {
            if (string.IsNullOrWhiteSpace(model.SearchQuery))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return this.GetResponse<ContentSearchRequest, IEnumerable<SearchDocumentDto>>(
                model,
                documents => documents.Any());
        }
    }
}

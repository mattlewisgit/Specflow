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

        [HttpGet]
        [Route("api/search/")]
        public HttpResponseMessage Search(string searchQuery, string orderBy, int pageSize, int pageNo)
        {
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            return this.GetResponse<ContentSearchRequest, IEnumerable<SearchDocumentDto>>(
                new ContentSearchRequest(searchQuery, orderBy, pageSize, pageNo),
                documents => documents.Any());
        }
    }
}

using System.Collections.Generic;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.ContentSearch
{
    public class ContentSearchRequest : IRequest<SearchDocumentDto>, IRequest<List<SearchDocumentDto>>
    {
        public string SearchQuery { get; set; }
        public string OrderBy { get; set; }
        public string PageSize { get; set; }
        public string PageNo { get; set; }     
    }
}

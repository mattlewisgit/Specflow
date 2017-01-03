using System.Collections.Generic;
using MediatR;

namespace Vitality.Website.Areas.Presales.Handlers.ContentSearch
{
    public class ContentSearchRequest : IRequest<SearchDocumentDto>, IRequest<List<SearchDocumentDto>>
    {
        public readonly string SearchQuery;

        public readonly string OrderBy;

        public readonly int PageSize;

        public readonly int PageNo;

        public ContentSearchRequest(string searchQuery, string orderBy, int pageSize, int pageNo)
        {
            SearchQuery = searchQuery;
            OrderBy = orderBy;
            PageSize = pageSize;
            PageNo = pageNo;
        }
    }
}
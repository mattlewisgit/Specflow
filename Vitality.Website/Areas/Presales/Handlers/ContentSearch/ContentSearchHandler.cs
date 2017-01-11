using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MediatR;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;

namespace Vitality.Website.Areas.Presales.Handlers.ContentSearch
{
    public class ContentSearchHandler : IRequestHandler<ContentSearchRequest, IEnumerable<SearchDocumentDto>>
    {
        private readonly ISearchIndex _searchIndex = ContentSearchManager.GetIndex("vitality_site_content");

        public ContentSearchHandler()
        {
            //_searchIndex.Rebuild();
        }

        public IEnumerable<SearchDocumentDto> Handle(ContentSearchRequest message)
        {
            using (var context = _searchIndex.CreateSearchContext())
            {   
                var pathToSearch = string.Format
                    ("/sitecore/content/{0}/home", Sitecore.Context.Site.Name);

                var predecate = PredicateBuilder.True<ContentSearchResult>();

                predecate = predecate.And(p => p.Path.StartsWith(pathToSearch));
                
                var query = context.GetQueryable<ContentSearchResult>().Where(predecate);
                
                // Getting pagination data
                int skipRecords = (message.PageNo - 1) * message.PageSize;
                query = query.Skip(skipRecords).Take(message.PageSize);
                
                // Return results; 
                return SearchDocumentDto.From(query.ToList(), message.SearchQuery);
            }
        }
    }
}
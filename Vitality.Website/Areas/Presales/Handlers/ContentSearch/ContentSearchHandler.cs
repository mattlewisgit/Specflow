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
        public ContentSearchHandler()
        {
            //_searchIndex.Rebuild();
        }

        public IEnumerable<SearchDocumentDto> Handle(ContentSearchRequest message)
        {
            var currentSite = Sitecore.Context.Site.Name;

            var pathToSearch = string.Format("/sitecore/content/{0}/home", currentSite);

            var indexName = string.Format("{0}_site_content", currentSite);

            var searchIndex = ContentSearchManager.GetIndex(indexName);

            using (var context = searchIndex.CreateSearchContext())
            { 
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
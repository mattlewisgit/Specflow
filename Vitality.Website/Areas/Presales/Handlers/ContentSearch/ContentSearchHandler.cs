using System.Collections.Generic;
using System.Linq;
using MediatR;
using Sitecore.ContentSearch;

namespace Vitality.Website.Areas.Presales.Handlers.ContentSearch
{
    public class ContentSearchHandler : IRequestHandler<ContentSearchRequest, IEnumerable<SearchDocumentDto>>
    {
        private ISearchIndex SearchIndex = ContentSearchManager.GetIndex("presales_content");

        public ContentSearchHandler()
        {
            SearchIndex.Rebuild();
        }

        public IEnumerable<SearchDocumentDto> Handle(ContentSearchRequest message)
        {
            using (var context = SearchIndex.CreateSearchContext())
            {   
                var pathToSearch = string.Format
                    ("/sitecore/content/{0}/home", Sitecore.Context.Site.Name);

                var query = context.GetQueryable<ContentSearchResult>()
                    .Where(p => p.Path.StartsWith(pathToSearch))
                    .Where(n => (n.Description.Contains(message.SearchQuery)) || (n.Name.Contains(message.SearchQuery)));

                if (!string.IsNullOrEmpty(message.OrderBy))
                {
                    if (message.OrderBy == "asc")
                        query = query.OrderBy(p => p.Title);
                    else if (message.OrderBy == "desc")
                        query = query.OrderByDescending(p => p.Title);
                }

                // Getting pagination data
                int skipRecords = (message.PageNo - 1) * message.PageSize;
                query = query.Skip(skipRecords).Take(message.PageSize);

                var results = query.ToList();

                // Return results; 
                return SearchDocumentDto.From(results);
            }
        }
    }
}
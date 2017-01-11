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
                //predecate = predecate.And(x => CultureInfo.CurrentCulture.CompareInfo.IndexOf(x.Description, message.SearchQuery, CompareOptions.IgnoreCase) >= 0);
                //predecate = predecate.Or(x => CultureInfo.CurrentCulture.CompareInfo.IndexOf(x.Title, message.SearchQuery, CompareOptions.IgnoreCase) >= 0);

                //predecate = predecate.And(x => x.Description.Contains(message.SearchQuery));

                var query = context.GetQueryable<ContentSearchResult>().Where(predecate);

                //var query = context.GetQueryable<ContentSearchResult>()
                //    .Where(p => p.Path.StartsWith(pathToSearch))
                //    .Where(n => (n.Description.Contains(message.SearchQuery)) || (n.Name.Contains(message.SearchQuery)));

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
                
                // Return results; 
                return SearchDocumentDto.From(query.ToList(), message.SearchQuery);
            }
        }
    }
}
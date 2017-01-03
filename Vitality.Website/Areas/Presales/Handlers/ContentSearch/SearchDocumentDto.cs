using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Links;
using Vitality.Website.Areas.Presales.Controllers;
using Vitality.Website.Areas.Presales.Handlers.Literature;

namespace Vitality.Website.Areas.Presales.Handlers.ContentSearch
{
    public class SearchDocumentDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public static IEnumerable<SearchDocumentDto> From(IEnumerable<ContentSearchResult> searchResult1)
        { 
            return searchResult1.Select(searchResult => new SearchDocumentDto
            {
                Title = searchResult.Title,
                Description = searchResult.Description,
                Path = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(searchResult.Path))
            }).ToList();
        }       
    }
}
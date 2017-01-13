using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;

namespace Vitality.Website.Areas.Presales.Handlers.ContentSearch
{
    public class ContentSearchResult : SearchResultItem
    {
        [IndexField("title")]
        public string Title { get; set; }
        [IndexField("description")]
        public string Description { get; set; } 
    }
}
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.PageTemplates
{
    public class ContentSearchPage : SitecoreItem
    {
        public string Headline { get; set; }
        public string SearchPlaceholderText { get; set; }  
        public int SearchPageSize { get; set; }   
        public string SearchStatus { get; set; }
    }
}

using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.Handlers.ContentSearch
{
    public class SearchDocumentDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public IEnumerable<string> Breadcrumbs { get; set; }
    }
}

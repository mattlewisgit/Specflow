using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Sitecore.ContentSearch.Linq;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Sites;
using Vitality.Website.Areas.Presales.Controllers;
using Vitality.Website.Areas.Presales.Handlers.Literature;
using Vitality.Website.Areas.Presales.Models;

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
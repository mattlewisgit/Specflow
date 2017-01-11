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

        public static IEnumerable<SearchDocumentDto> From(IEnumerable<ContentSearchResult> searchResult1, string searchQuery)
        {
            return (from searchResult in searchResult1 
                    where CultureInfo.CurrentCulture.CompareInfo.IndexOf(searchResult.Description, searchQuery, CompareOptions.IgnoreCase) >= 0 ||
                    CultureInfo.CurrentCulture.CompareInfo.IndexOf(searchResult.Description, searchQuery, CompareOptions.IgnoreCase) >= 0
                        select new SearchDocumentDto
                        {
                            Title = searchResult.Title,
                            Description = searchResult.Description,
                            Path = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(searchResult.Path)),
                            Breadcrumbs = GetBreadcrumbs(searchResult.GetItem())
                        }).ToList();
        }

        public static IEnumerable<string> GetBreadcrumbs(Item currentItem)
        {   
            Stack<Breadcrumb> breadcrumbs = new Stack<Breadcrumb>();
            var site = SiteContext.Current;
            var homeItem = site.StartPath;

            while (currentItem != null)
            {
                // Ignore the home node and above.
                // Brilliantly, the paths can be the same, but mixed case, so ignore that!
                if (currentItem.Paths.Path.Equals
                    (homeItem, StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                breadcrumbs.Push(new Breadcrumb
                {
                    Name = currentItem.DisplayName,
                    Url = LinkManager.GetItemUrl(currentItem),
                });

                currentItem = currentItem.Parent;
            }
            
            // Only want to show this if more than one element in the list
            return breadcrumbs.Select(x => x.Name).Count() > 1 ? breadcrumbs.Select(x => x.Name) : new List<string>();
        }
    }
}
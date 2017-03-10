using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MediatR;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Sites;
using Vitality.Website.Areas.Presales.Models;

namespace Vitality.Website.Areas.Presales.Handlers.ContentSearch
{
    public class ContentSearchHandler : IRequestHandler<ContentSearchRequest, IEnumerable<SearchDocumentDto>>
    {
        public IEnumerable<SearchDocumentDto> Handle(ContentSearchRequest message)
        {
            var currentSite = Sitecore.Context.Site.Name;

            var pathToSearch = string.Format("/sitecore/content/{0}/home", currentSite);

            var indexName = string.Format("{0}_site_content", currentSite);
            
            using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
            { 
                var predecate = PredicateBuilder.True<ContentSearchResult>();

                predecate = predecate.And(p => p.Path.StartsWith(pathToSearch));
                
                var query = context.GetQueryable<ContentSearchResult>().Where(predecate);
                
                // Return results; 
                return From(query.ToList(), message.SearchQuery, message.PageSize);
            }
        }

        public static IEnumerable<SearchDocumentDto> From(IEnumerable<ContentSearchResult> searchResults, string searchQuery, string pageSize)
        {
            var pageCount = !string.IsNullOrEmpty(pageSize) ? Int32.Parse(pageSize) : 0;

            return (from result in searchResults
                    where FilterCase(searchQuery, result.Description) || FilterCase(searchQuery, result.Title)
                    select new SearchDocumentDto
                    {
                        Title = result.Title,
                        Description = result.Description,
                        Path = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(result.Path)),
                        Breadcrumbs = GetBreadcrumbs(result.GetItem())
                    }).ToList().Take(pageCount);
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

        private static bool FilterCase(string searchQuery, string property)
        {
            if(!string.IsNullOrEmpty(searchQuery) && !string.IsNullOrEmpty(property))
                return CultureInfo.CurrentCulture.CompareInfo.IndexOf(property, searchQuery, CompareOptions.IgnoreCase) >= 0;

            return false;
        }                
    }
}

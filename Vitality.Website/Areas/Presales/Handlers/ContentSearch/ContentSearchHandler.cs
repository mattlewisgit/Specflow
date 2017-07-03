using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MediatR;
using Sitecore.ContentSearch;
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

            var pathToSearch = $"/sitecore/content/{currentSite}/home";

            var indexName = $"{currentSite}_site_content";

            using (var context = ContentSearchManager.GetIndex(indexName).CreateSearchContext())
            {
                var predecate = PredicateBuilder.True<ContentSearchResult>();

                predecate = predecate.And(p => p.Path.StartsWith(pathToSearch) && !p.HideFromSearch);

                var query = context.GetQueryable<ContentSearchResult>().Where(predecate);

                return From(query.ToList(), message.SearchQuery, message.PageSize);
            }
        }

        public static IEnumerable<SearchDocumentDto> From(IEnumerable<ContentSearchResult> searchResults, string searchQuery, string pageSize)
        {
            var pageCount = !string.IsNullOrEmpty(pageSize) ? int.Parse(pageSize) : 0;

            return (from result in searchResults
                    where FilterCase(searchQuery, result.Description) || FilterCase(searchQuery, result.Title)
                    select new SearchDocumentDto
                    {
                        Title = result.Title,
                        Description = result.Description,
                        Path = LinkManager.GetItemUrl(Sitecore.Context.Database.GetItem(result.Path)),
                        Breadcrumbs = GetBreadcrumbs(result.GetItem())
                    }).Take(pageCount);
        }


        public static IEnumerable<string> GetBreadcrumbs(Item currentItem)
        {
            Stack<Breadcrumb> breadcrumbs = new Stack<Breadcrumb>();
            var site = SiteContext.Current;
            var homeItem = site.StartPath;
            var item = currentItem;

            while (item != null)
            {
                // Ignore the home node and above.
                // Brilliantly, the paths can be the same, but mixed case, so ignore that!
                if (item.Paths.Path.Equals
                    (homeItem, StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                breadcrumbs.Push(new Breadcrumb
                {
                    Name = item.DisplayName,
                    Url = LinkManager.GetItemUrl(item),
                });

                item = item.Parent;
            }

            // Only want to show this if more than one element in the list
            return breadcrumbs.Select(x => x.Name).Count() > 1 ? breadcrumbs.Select(x => x.Name) : new List<string>();
        }

        private static bool FilterCase(string searchQuery, string property) =>
            !string.IsNullOrEmpty(searchQuery) &&
            !string.IsNullOrEmpty(property) &&
            CultureInfo.CurrentCulture.CompareInfo.IndexOf
                (property, searchQuery, CompareOptions.IgnoreCase) >= 0;
    }
}

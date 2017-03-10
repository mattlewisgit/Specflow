using System.Collections.Generic;
using Sitecore.Sites;
using Vitality.Website.Areas.Presales.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Navigation
{
    using System;

    public class BreadcrumbTrail
    {
        public Stack<Breadcrumb> Breadcrumbs { get; set; }

        public BreadcrumbTrail()
        {
            var currentItem = Sitecore.Context.Item;
            var site = SiteContext.Current;
            var homeItem = site.StartPath;
            Breadcrumbs = new Stack<Breadcrumb>();

            while (currentItem != null)
            {
                // Ignore the home node and above.
                // Brilliantly, the paths can be the same, but mixed case, so ignore that!
                if (currentItem.Paths.Path.Equals
                    (homeItem, StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }

                Breadcrumbs.Push(new Breadcrumb
                {
                    Name = currentItem.DisplayName,
                    Url = Sitecore.Links.LinkManager.GetItemUrl(currentItem),
                });

                currentItem = currentItem.Parent;
            }
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Sites;
using Vitality.Website.Areas.Presales.Models;
using Vitality.Website.SC.Utilities;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Navigation
{
    public class BreadcrumbTrail
    {
        public ICollection<Breadcrumb> Breadcrumbs { get; set; }

        public BreadcrumbTrail()
        {
            var currentItem = Sitecore.Context.Item;
            var site = SiteContext.Current;
            var homeItem = site.StartItem;

            Breadcrumbs = new List<Breadcrumb>();

            var index = 0;
            while (currentItem != null)
            {
                Breadcrumbs.Add(new Breadcrumb
                {
                  Name =currentItem.Name,
                  Url = currentItem.Uri.Path,
                  Position  = index
                });

                if (currentItem.Paths.Path  == homeItem)
                    break;

                currentItem = currentItem.Parent;
            }

            Breadcrumbs.Reverse();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Sites;
using Vitality.Website.SC.Utilities;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.Navigation
{
    public class BreadcrumbTrail
    {
        public ICollection<Item> Breadcrumbs { get; set; }

        public BreadcrumbTrail(Item current, SiteContext site)
        {
            var homeItem = site.StartItem;

            Breadcrumbs = new List<Item>();

            while (current != null)
            {
                Breadcrumbs.Add(current);

                //if (current.)
                //    break;

                current = current.Parent;
            }

            Breadcrumbs.Reverse();
        }
    }
}
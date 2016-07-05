using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Publishing.Pipelines.GetItemReferences;
using Sitecore.Publishing.Pipelines.PublishItem;

namespace Vitality.Website.SC.Pipelines.Publishing.GetItemReferences
{
    public class AddDataSourceItemDescendants : GetItemReferencesProcessor
    {
        private readonly List<string> pathsToIgnore = new List<string>();

        public void AddPath(string path)
        {
            pathsToIgnore.Add(path);
        }

        protected override List<Item> GetItemReferences(PublishItemContext context)
        {
            // Get context items Related Items
            var referredItem = context.Result.ReferredItems.Select(pc => context.PublishHelper.GetSourceItem(pc.ItemId)).ToArray();

            var itemsToPublish = new List<Item>();
            // Iterate over Related Items that are datasource items
            foreach (var item in referredItem.Where(ItemIsDataSource))
            {
                // Add datasource items to publishing queue, if not already present (includes the items referrer items)
                if (!referredItem.Contains(item) && !itemsToPublish.Contains(item))
                {
                    itemsToPublish.AddRange(GetLinkedItems(item));
                }

                // Add Related Items child items to publishing queue, if not already present (includes the items referrer items)
                foreach (Item child in item.Children)
                {
                    if (!referredItem.Contains(child) && !itemsToPublish.Contains(child))
                    {
                        itemsToPublish.AddRange(GetLinkedItems(child));
                    }
                }
            }

            return itemsToPublish;
        }

        private IEnumerable<Item> GetLinkedItems(Item contextItem)
        {
            // Retrieve the items referrer items
            var links = contextItem.Links.GetValidLinks();
            // Return referrer items which are datasource items
            return links.Select(link => contextItem.Database.GetItem(link.TargetItemID)).Where(targetItem => targetItem != null && ItemIsDataSource(targetItem));
        }

        private bool ItemIsDataSource(Item item)
        {
            return item.Paths.FullPath.StartsWith(ItemConstants.Presales.Content.ContentFolder.Path) &&
                   !pathsToIgnore.Any(path => item.Paths.FullPath.StartsWith(path));
        }
    }
}

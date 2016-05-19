using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
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
            var referredItem = context.Result.ReferredItems.Select(pc => context.PublishHelper.GetSourceItem(pc.ItemId)).ToArray();

            var itemsToPublish = new List<Item>();
            foreach (var item in referredItem)
            {
                if (item.Paths.FullPath.StartsWith("/sitecore/content/Presales/Content") && !pathsToIgnore.Any(path => item.Paths.FullPath.StartsWith(path)))
                {
                    foreach (Item child in item.Children)
                    {
                        if (!referredItem.Contains(child) && !itemsToPublish.Contains(child))
                        {
                            itemsToPublish.Add(child);
                        }
                    }
                    
                }
            }

            return itemsToPublish;
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Publishing.Pipelines.GetItemReferences;
using Sitecore.Publishing.Pipelines.PublishItem;
using Sitecore.Web;
using Vitality.Website.SC.Utilities;

namespace Vitality.Website.SC.Pipelines.Publishing.GetItemReferences
{
    public class AddDataSourceItemDescendants : GetItemReferencesProcessor
    {
        private readonly List<string> pathsToIgnore = new List<string>();
        private readonly IEnumerable<SiteInfo> _siteInfoList= Sitecore.Configuration.Factory.GetSiteInfoList().RemoveSitecoreShellSiteInfos();
        public void AddPath(string path)
        {
            pathsToIgnore.Add(path);
        }
                   
        protected override List<Item> GetItemReferences(PublishItemContext context)
        {
            var referredDataSourceItems = GetCurrentPublishCandidateItems(context);
            var itemsToPublish = new List<Item>();

            foreach (var item in referredDataSourceItems.Where(ItemIsDataSource))
            {
                if (!itemsToPublish.Contains(item))
                {
                    itemsToPublish.AddRange(GetLinkedDataSourceItems(item));
                }

                foreach (Item child in item.Children)
                {
                    itemsToPublish.Add(child);
                    if (!referredDataSourceItems.Contains(child) && !itemsToPublish.Contains(child))
                    {
                        itemsToPublish.AddRange(GetLinkedDataSourceItems(child));
                    }
                }
            }

            return itemsToPublish;
        }

        private static Item[] GetCurrentPublishCandidateItems(PublishItemContext context)
        {
            return context.Result.ReferredItems.Select(publishCandidate => context.PublishHelper.GetSourceItem(publishCandidate.ItemId)).ToArray();
        }

        private IEnumerable<Item> GetLinkedDataSourceItems(Item contextItem)
        {
            return contextItem
                .Links
                .GetValidLinks()
                .Select(link => contextItem.Database.GetItem(link.TargetItemID))
                .Where(ItemIsDataSource);
        }

        private bool ItemIsDataSource(Item item)
        {
            var currentSiteContentStartPath = item.GetSiteContentStartPath(_siteInfoList);
            return item.Paths.FullPath.StartsWith(
                currentSiteContentStartPath + ItemConstants.Presales.Content.ContentFolder.RelativePath,
                StringComparison.InvariantCultureIgnoreCase) &&
                !pathsToIgnore.Any(path => item.Paths.FullPath.StartsWith(currentSiteContentStartPath + path,
                StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

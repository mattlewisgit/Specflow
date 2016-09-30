﻿using System;
using System.Collections.Generic;
using Sitecore.Web;

namespace Vitality.Website.SC.Events
{
    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Events;

    using Vitality.Website.SC.Utilities;

    public class ItemEventsHandler
    {
        private static readonly ID fieldTemplateId = new ID("{455A3E98-A627-4B40-8035-E683A0331AC7}");
        private static readonly IEnumerable<SiteInfo> siteInfoList = Sitecore.Configuration.Factory.GetSiteInfoList().RemoveSitecoreShellSiteInfos();
        public void SetSeoFriendlyItemName(object sender, EventArgs args)
        {
            var item = this.GetItem(args);

            if (ItemIsMasterDatabaseContentPage(item))
            {
                var hyphenatedName = StringHelper.HyphenatedWords(item.Name).ToLowerInvariant();
                if (!item.Name.Equals(hyphenatedName, StringComparison.Ordinal))
                {
                    using (new EditContext(item))
                    {
                        item.Appearance.DisplayName = item.Name;
                        item.Name = hyphenatedName;
                    }
                }
            }
        }

        public void SetSplitCamelCaseFieldTitle(object sender, EventArgs args)
        {
            var item = this.GetItem(args);

            if (item != null && ItemIsMasterDatabaseTemplateField(item))
            {
                if (FieldItemTitleIsNotSplitCamelCase(item))
                {
                    using (new EditContext(item))
                    {
                        item.Fields["Title"].SetValue(StringHelper.SplitCamelCase(item.Name), false);
                    }
                }
            }
        }

        public void SetSubFolderInsertOptions(object sender, EventArgs args)
        {
            var item = this.GetItem(args);
            if (ItemIsMasterDatabaseSubFolder(item))
            {
                var insertOptions = item.Parent["__Masters"];
                using (new EditContext(item))
                {
                    item["__Masters"] = insertOptions;
                }
            }
        }

        private static bool ItemIsMasterDatabaseContentPage(Item item)
        {
            if (item == null || !string.Equals(item.Database.Name, "master", StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }
            var currentSiteContentStartPath = item.GetSiteContentStartPath(siteInfoList);
            return item.Paths.FullPath.StartsWith(
                currentSiteContentStartPath + ItemConstants.Presales.Content.Home.RelativePath,
                StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool ItemIsMasterDatabaseTemplateField(Item item)
        {
            return item != null && item.Database.Name == "master"
                && item.TemplateID.Equals(TemplateIDs.TemplateField);
        }

        private static bool ItemIsMasterDatabaseSubFolder(Item item)
        {
            return item != null && item.Database.Name == "master"
                   && item.TemplateID.Guid.Equals(ItemConstants.Global.Templates.Subfolder.Id)
                   && !item.Name.Equals("__Standard Values", StringComparison.OrdinalIgnoreCase);
        }

        private static bool FieldItemTitleIsNotSplitCamelCase(Item item)
        {
            return item.TemplateID == fieldTemplateId 
                && item.Fields["Title"] != null 
                && item.Fields["Title"].Value != StringHelper.SplitCamelCase(item.Name);
        }

        private Item GetItem(EventArgs args)
        {
            return Event.ExtractParameter(args, 0) as Item;
        }
    }
}

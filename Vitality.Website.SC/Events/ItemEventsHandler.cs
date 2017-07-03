namespace Vitality.Website.SC.Events
{
    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Events;
    using Sitecore.Web;
    using System;
    using System.Collections.Generic;
    using Core;
    using Utilities;

    public class ItemEventsHandler
    {
        private static readonly ID fieldTemplateId = new ID("{455A3E98-A627-4B40-8035-E683A0331AC7}");
        private static readonly IEnumerable<SiteInfo> siteInfoList = Sitecore.Configuration.Factory.GetSiteInfoList().RemoveSitecoreShellSiteInfos();

        public void SetSeoFriendlyItemName(object sender, EventArgs args)
        {
            var item = GetItem(args);

            if (ItemIsMasterDatabaseContentPage(item))
            {
                var hyphenatedName = item.Name.ToLowerHyphenatedWords();
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
            var item = GetItem(args);

            if (item != null && ItemIsMasterDatabaseTemplateField(item) && FieldItemTitleIsNotSplitCamelCase(item))
            {
                using (new EditContext(item))
                {
                    item.Fields["Title"].SetValue(item.Name.SplitCamelCase(), false);
                }
            }
        }

        public void SetSubFolderInsertOptions(object sender, EventArgs args)
        {
            var item = GetItem(args);
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

        private static bool FieldItemTitleIsNotSplitCamelCase(Item item) =>
            item.TemplateID == fieldTemplateId
                && item.Fields["Title"] != null
                && item.Fields["Title"].Value != item.Name.SplitCamelCase();

        private Item GetItem(EventArgs args) =>
            Event.ExtractParameter(args, 0) as Item;
    }
}

using System;

namespace Vitality.Website.SC.Events
{
    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Events;

    using Vitality.Website.SC.Utilities;

    public class ItemEventsHandler
    {
        private readonly ID fieldTemplateId = new ID("{455A3E98-A627-4B40-8035-E683A0331AC7}");

        public void SetSeoFriendlyItemName(object sender, EventArgs args)
        {
            var item = this.GetItem(args);

            if (ItemIsMasterDatabaseContentPage(item))
            {
                var hyphenatedName = StringHelper.HyphenatedWords(item.Name);
                if (!item.Name.Equals(hyphenatedName, StringComparison.Ordinal))
                {
                    using (new EditContext(item))
                    {
                        item.Appearance.DisplayName = item.Name;
                        item.Name = hyphenatedName.ToLowerInvariant();
                    }
                }
            }
        }

        public void SetSplitCamelCaseFieldTitle(object sender, EventArgs args)
        {
            var item = this.GetItem(args);

            if (item != null && ItemIsMasterDatabaseTemplateField(item))
            {
                if (item.TemplateID == this.fieldTemplateId && item.Fields["Title"] != null)
                {
                    item.Fields["Title"].SetValue(StringHelper.SplitCamelCase(item.Name), false);
                }
            }
        }

        private static bool ItemIsMasterDatabaseContentPage(Item item)
        {
            return item != null && item.Database.Name == "master"
                   && item.Paths.FullPath.StartsWith(ItemConstants.Presales.Content.Home.Path, StringComparison.OrdinalIgnoreCase);
        }

        private static bool ItemIsMasterDatabaseTemplateField(Item item)
        {
            return item != null && item.Database.Name == "master"
                   && item.TemplateID.Equals(TemplateIDs.TemplateField);
        }

        private Item GetItem(EventArgs args)
        {
            return Event.ExtractParameter(args, 0) as Item;
        }
    }
}

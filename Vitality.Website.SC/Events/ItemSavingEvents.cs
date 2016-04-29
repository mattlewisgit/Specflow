using System;

namespace Vitality.Website.SC.Events
{
    using System.Text.RegularExpressions;

    using Sitecore;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Events;

    public class ItemSavingEvents
    {
        private const string FieldNameTitle = "Title";
        private readonly ID fieldTemplateId = new ID("{455A3E98-A627-4B40-8035-E683A0331AC7}");

        public void SetSplitCamelCaseFieldTitle(object sender, EventArgs args)
        {
            var contextItem = Event.ExtractParameter(args, 0) as Item;

            if (contextItem != null && ItemIsMasterDatabaseTemplateField(contextItem))
            {
                if (contextItem.TemplateID == this.fieldTemplateId && contextItem.Fields[FieldNameTitle] != null)
                {
                    contextItem.Fields[FieldNameTitle].SetValue(SplitCamelCase(contextItem.Name), false);
                }
            }
        }

        private static string SplitCamelCase(string input)
        {
            return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }

        private static bool ItemIsMasterDatabaseTemplateField(Item item)
        {
            return item != null && item.Database.Name == "master"
                   && item.TemplateID.Equals(TemplateIDs.TemplateField);
        }
    }
}

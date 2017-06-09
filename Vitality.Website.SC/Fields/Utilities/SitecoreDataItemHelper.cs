using System;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace Vitality.Website.SC.Utilities
{
    public static class SitecoreDataItemHelper
    {
        public static bool PathStartsWith(this Item item, Item itemToCheck, StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase)
        {
           return  item.Paths.LongID.StartsWith(itemToCheck.Paths.LongID, stringComparison);
        }

        public static string GetRelativePath(this Item item, Item itemToCheck)
        {
            return item.Paths.LongID.Substring(itemToCheck.Paths.LongID.Length);
        }
    }
}

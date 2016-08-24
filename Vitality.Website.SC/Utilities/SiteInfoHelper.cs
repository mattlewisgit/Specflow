using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Web;

namespace Vitality.Website.SC.Utilities
{
    public static class SiteInfoHelper
    {
        public static IEnumerable<SiteInfo> GetSiteInfoList()
        {
            return Sitecore.Configuration.Factory.GetSiteInfoList().Where(siteInfo =>
                !string.Equals(siteInfo.Domain, "sitecore", StringComparison.InvariantCultureIgnoreCase)
                && !string.IsNullOrEmpty(siteInfo.Domain));
        }

        public static SiteInfo GetSite(this Sitecore.Data.Items.Item item, IEnumerable<SiteInfo> siteInfoList)
        {
            SiteInfo currentSiteinfo = null;
            var matchLength = 0;
            foreach (var siteInfo in siteInfoList)
            {
                if (!item.Paths.FullPath.StartsWith(siteInfo.RootPath, StringComparison.OrdinalIgnoreCase) ||
                    siteInfo.RootPath.Length <= matchLength)
                {
                    continue;
                }
                matchLength = siteInfo.RootPath.Length;
                currentSiteinfo = siteInfo;
            }
            return currentSiteinfo;
        }

        public static string GetSiteContentStartPath(this Sitecore.Data.Items.Item item, IEnumerable<SiteInfo> siteInfoList)
        {
            var currentSite = item.GetSite(siteInfoList);
            return currentSite == null ? string.Empty : currentSite.RootPath;
        }
    }
}

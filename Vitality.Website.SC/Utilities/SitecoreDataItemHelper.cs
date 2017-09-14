using System.Web;
using System.Web.Configuration;

namespace Vitality.Website.SC.Utilities
{
    using System;
    using Sitecore.Data.Items;

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

        /// <summary>
        /// 	Build URL path.
        /// </summary>
        /// <param name="path"> Domain path. </param>
        /// <param name="secured"> Is secure connection. </param>
        /// <returns> Path of the domain. </returns>
        public static string BuildUrl(string path, bool secured)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                string httpsUrl = "https://" + HttpContext.Current.Request.Url.Host
                                  + "/" + path.TrimStart('/');
                string httpUrl = "http://" + HttpContext.Current.Request.Url.Host
                                 + "/" + path.TrimStart('/');

                if (secured)
                {
                    return httpsUrl;
                }
                else
                {
                    bool isSecureConnection = String.Equals(
                        HttpContext.Current.Request.Headers["X-Forwarded-Proto"],
                        "https",
                        StringComparison.OrdinalIgnoreCase);

                    if (isSecureConnection || HttpContext.Current.Request.IsSecureConnection)
                    {
                        return httpsUrl;
                    }
                    else
                    {
                        return httpUrl;
                    }
                }
            }
            else
            {
                return path;
            }
        }

        /// <summary>
        /// 	Build URL path.
        /// </summary>
        /// <param name="path"> Domain path. </param>
        /// <returns> Path of the domain. </returns>
        public static string BuildUrl(string path)
        {
            return BuildUrl(path, false);
        }
    }
}

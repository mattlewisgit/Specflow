using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Forms.Mvc.Extensions;
using Vitality.Website.App.SocialMedia;
using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.Areas.Presales.ComponentTemplates.Articles;
using Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection;
using Vitality.Website.Areas.Presales.SettingsTemplates;

namespace Vitality.Website.Extensions.Views
{
    public static class ContentCollectionExtensions
    {
        public static IEnumerable<ContentItem<object>> GetContentItemsAsOneList(this ContentCollection contentCollection)
        {
            var allContentItems = new List<ContentItem<object>>();
            allContentItems.AddContentItem(contentCollection.LargeArticles, "_LargeArticle");
            allContentItems.AddContentItem(contentCollection.MediumArticles, "_MediumArticle");
            allContentItems.AddContentItem(contentCollection.SmallArticles, "_SmallArticle");
            allContentItems.AddContentItem(contentCollection.SocialMediaSections, "_SocialMedias");
            allContentItems.AddContentItem(contentCollection.MpuSections, "_Mpus");

            return allContentItems.OrderBy(o => o.SortOrder);
        }

        private static void AddContentItem<T>(this List<ContentItem<T>> allContentItems, IEnumerable<T> itemsToAdd,
            string partialViewName)
        {
            allContentItems.AddRange(itemsToAdd.Select(item => new ContentItem<T>
            {
                Item = item,
                PartialView = partialViewName,
                SortOrder = item.GetPropertyValue<int>("SortOrder")
            }));
        }

        public static string ColumnCss(this ContentCollection contentCollection, string column)
        {
            if (string.Equals(contentCollection.LargeColumnSide, column, StringComparison.OrdinalIgnoreCase))
            {
                return "grid-col-8-12";
            }
            return "grid-col-4-12";
        }

        public static string SmallArticleTextCss(this SmallArticle smallArticle)
        {
            return string.Format("text-{0}", smallArticle.ColourScheme);
        }

        public static string LargeArticleTextCss(this LargeArticle largeArticle)
        {
            return string.Format("text-{0}", largeArticle.ColourScheme);
        }

        public static string LargeArticleButtonCss(this LargeArticle largeArticle)
        {
            if (string.Equals(largeArticle.ColourScheme, "dark", StringComparison.OrdinalIgnoreCase))
            {
                return "box-button box-button--rounded";
            }
            return "box-button box-button--light box-button--rounded";
        }
        
        public static int GetSocialMediaCounts(this SocialMediaSetting socialMediaSetting)
        {
            var socialMediaAccount = new SocialMediaAccount
            {
                AppKey = socialMediaSetting.AppKey,
                AppSecret = socialMediaSetting.AppSecret
            };
            if (string.Equals(socialMediaSetting.SiteName, "facebook", StringComparison.OrdinalIgnoreCase))
            {
                var facebookConnector = new FacebookConnector(socialMediaAccount);
                facebookConnector.GetFollowersOrLikesCount(socialMediaSetting.PageOrUserId,
                facebookConnector.GetAccessToken().AccessToken);
            }
            else if (string.Equals(socialMediaSetting.SiteName, "twitter", StringComparison.OrdinalIgnoreCase))
            {
                var twitterConnector = new FacebookConnector(socialMediaAccount);
                twitterConnector.GetFollowersOrLikesCount(socialMediaSetting.PageOrUserId,
                twitterConnector.GetAccessToken().AccessToken);

            }
            return 0;
        }
    }
}
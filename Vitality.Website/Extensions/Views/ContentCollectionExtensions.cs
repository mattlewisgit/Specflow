using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using log4net;
using Sitecore.ContentSearch.Linq;
using Sitecore.Forms.Mvc.Extensions;
using Vitality.Website.App.Handlers;
using Vitality.Website.App.SocialMedia;
using Vitality.Website.App.SocialMedia.Models;
using Vitality.Website.Areas.Presales.ComponentTemplates.Articles;
using Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection;
using Vitality.Website.Areas.Presales.Handlers;

namespace Vitality.Website.Extensions.Views
{
    public static class ContentCollectionExtensions
    {
        private static readonly ObjectCache MemoryCacheStore = MemoryCache.Default;
        private static readonly ILog Logger = PresalesLog.Log;

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

        /// <summary>
        /// Get number of Facebook likes and number of Twitter Followers
        /// </summary>
        /// <param name="socialMediaItem">Social Media Item with Settings</param>
        /// <param name="attempt">Use attempt to try again as Access Token might be expired first time expired</param>
        /// <returns></returns>
        public static string GetSocialMediaCounts(this SocialMediaItem socialMediaItem, int attempt = 0)
        {
            var settings = socialMediaItem.Settings;

            var socialMediaAccount = new SocialMediaAccount
            {
                AppKey = settings.AppKey,
                AppSecret = settings.AppSecret
            };
            //Fail gracefully but log it
            try
            {
                if (string.Equals(settings.SiteIdentifier, SocialMediaConstants.Facebook,
                    StringComparison.OrdinalIgnoreCase))
                {
                    var facebookConnector = new FacebookConnector(socialMediaAccount);
                    var accessToken = GetAccessToken(facebookConnector.GetAccessToken, settings.SiteIdentifier);
                    return facebookConnector.GetLikesCount(settings.EntityId, accessToken).FanCount.ToString();
                }
                if (string.Equals(settings.SiteIdentifier, SocialMediaConstants.Twitter,
                    StringComparison.OrdinalIgnoreCase))
                {
                    var twitterConnector = new TwitterConnector(socialMediaAccount);
                    var accessTokenResponse = twitterConnector.GetAccessToken();
                    return twitterConnector.GetFollowersCount(settings.EntityId, accessTokenResponse.AccessToken).FollowersCount
                            .ToString();
                }
            }
            catch (Exception ex)
            {
                var statusCode = (HttpStatusCode)ex.Data[ApiResponseHandler.StatusCodeKey];
                //Only try twice
                if ((statusCode == HttpStatusCode.BadRequest || statusCode == HttpStatusCode.Unauthorized) &&
                    attempt == 0)
                {
                    MemoryCacheStore.Remove(string.Format("{0}_accessToken", settings.SiteIdentifier));
                    GetSocialMediaCounts(socialMediaItem, 1);
                } 
                Logger.Error(ex.Message, ex);
                return socialMediaItem.ErrorMessage;
            }
            return socialMediaItem.ErrorMessage;
        }

        private static string GetAccessToken(Func<AccessTokenResponse> getAccessToken, string siteIdentifier)
        {
            return (string)MemoryCacheStore.AddOrGetExisting(string.Format("{0}_accessToken", siteIdentifier), getAccessToken().AccessToken, DateTimeOffset.UtcNow.AddDays((1)));
        }
    }
}
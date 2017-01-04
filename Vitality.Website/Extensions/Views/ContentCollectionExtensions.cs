using System;
using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc.Web.Mvc;
using Sitecore.Forms.Mvc.Extensions;
using Vitality.Website.Areas.Presales.ComponentTemplates.Articles;
using Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection;
using Vitality.Website.Areas.Presales.ComponentTemplates.Generic;

namespace Vitality.Website.Extensions.Views
{
    public static class ContentCollectionExtensions
    {
        public static IEnumerable<ContentItem<object>> GetContentItemsAsOneList(this ContentCollection contentCollection)
        {
            var allContentItems = new List<ContentItem<object>>();
            allContentItems.AddAsIndividualItems(contentCollection.LargeArticles, "_LargeArticle");
            allContentItems.AddAsIndividualItems(contentCollection.MediumArticles, "_MediumArticle");
            allContentItems.AddAsIndividualItems(contentCollection.SmallArticles, "_SmallArticle");
            allContentItems.AddAsList(contentCollection.SocialMediaItems.ToList(), "_SocialMedias");
            allContentItems.AddAsList(contentCollection.Mpus.ToList(), "_Mpus");

            return allContentItems.OrderBy(o => o.SortOrder);
        }

        private static void AddAsIndividualItems<T>(this List<ContentItem<T>> allContentItems, IEnumerable<T> itemsToAdd,
            string partialViewName)
        {
            allContentItems.AddRange(itemsToAdd.Select(item => new ContentItem<T>
            {
                Item = item,
                PartialView = partialViewName,
                SortOrder = item.GetPropertyValue<int>("SortOrder")
            }));
        }

        private static void AddAsList<T>(this List<ContentItem<object>> allContentItems, List<T> itemsToAdd,
            string partialViewName)
        {
            allContentItems.AddRange(new List<ContentItem<object>>
            {
                new ContentItem<object>
                {
                    Item = new GroupedItem<T> {Items = itemsToAdd},
                    PartialView = partialViewName,
                    SortOrder = itemsToAdd.First().GetPropertyValue<int>("SortOrder")
                }
            });
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
    }
}
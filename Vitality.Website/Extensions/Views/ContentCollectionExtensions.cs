using System.Collections.Generic;
using System.Linq;
using Sitecore.Forms.Mvc.Extensions;
using Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection;
using Vitality.Website.Areas.Presales.ComponentTemplates.Generic;

namespace Vitality.Website.Extensions.Views
{
    public static class ContentCollectionExtensions
    {
        public static IEnumerable<ContentItem<object>> GetContentItemsAsOneList(this ContentCollection model)
        {
            var allContentItems = new List<ContentItem<object>>();
            allContentItems.AddAsIndividualItems(model.LargeArticles, "_LargeArticle");
            allContentItems.AddAsIndividualItems(model.MediumArticles, "_MediumArticle");
            allContentItems.AddAsIndividualItems(model.SmallArticles, "_SmallArticle");
            allContentItems.AddAsList(model.SocialMediaItems.ToList(), "_SocialMedias");
            allContentItems.AddAsList(model.Mpus.ToList(), "_Mpus");

            return allContentItems.OrderBy(o=>o.SortOrder);
        }

        private static void AddAsIndividualItems<T>(this List<ContentItem<T>> allContentItems, IEnumerable<T> itemsToAdd, string partialViewName) 
        {
            allContentItems.AddRange(itemsToAdd.Select(item => new ContentItem<T>
            {
                Item = item,
                PartialView = partialViewName,
                SortOrder = item.GetPropertyValue<int>("SortOrder")
            }));
        }

        private static void AddAsList<T>(this List<ContentItem<object>> allContentItems, List<T> itemsToAdd, string partialViewName)
        {
            allContentItems.AddRange(new List<ContentItem<object>> { new  ContentItem<object>
            {
                Item = new GroupedItem<T> { Items = itemsToAdd },
                PartialView = partialViewName,
                SortOrder = itemsToAdd.First().GetPropertyValue<int>("SortOrder")
            }});
        }
    }
}
namespace Vitality.Website.SC.ContentSearch.ComputedFields
{
    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.ComputedFields;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Resources.Media;
    using Sitecore.Sites;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class MediaItemReferenceUrlLink : IComputedIndexField
    {
        public object ComputeFieldValue(IIndexable indexable)
        {
            Assert.ArgumentNotNull(indexable, "indexable");
            var indexableItem = indexable as SitecoreIndexableItem;

            if (indexableItem == null)
            {
                Log.Warn(string.Format("{0} : unsupported IIndexable type : {1}", this, indexable.GetType()), this);
                return null;
            }

            var field = indexableItem.Item.Fields[FieldName];

            if (field == null)
            {
                return null;
            }

            return GetMediaItem(field);
        }

        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        private static string GetImageUrl(Field field)
        {
            var image = (ImageField)field;

            return image != null
                ? GetMediaUrl(image.MediaItem)
                : null;
        }

        private static string GetGeneralLinkUrl(Field field)
        {
            var mediaLink = (LinkField)field;

            if (mediaLink == null)
            {
                return null;
            }

            return mediaLink.IsInternal || mediaLink.IsMediaLink
                ? GetMediaUrl(Database.GetDatabase("web").GetItem(mediaLink.TargetID))
                : mediaLink.Url;
        }

        private static ReadOnlyDictionary<string, Func<Field, string>> fieldUrlGenerators =
            new ReadOnlyDictionary<string, Func<Field, string>>
                (new Dictionary<string, Func<Field, string>>
                {
                    { "general link", GetGeneralLinkUrl },
                    { "image", GetImageUrl }
                });

        private static string GetMediaItem(Field field)
        {
            if (field == null)
            {
                return null;
            }

            var fieldType = field.TypeKey;

            return fieldUrlGenerators.ContainsKey(fieldType)
                ? fieldUrlGenerators[fieldType](field)
                : null;
        }

        private static string GetMediaUrl(MediaItem mediaItem)
        {
            if (mediaItem == null)
            {
                return null;
            }

            var options = new MediaUrlOptions
            {
                AbsolutePath = false,
                AlwaysIncludeServerUrl = true,
                MediaLinkServerUrl = SiteContextFactory.GetSiteContext("advisers").HostName
            };

            return MediaManager.GetMediaUrl(mediaItem, options);
        }
    }
}

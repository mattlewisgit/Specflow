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
            
            var field = indexableItem.Item.Fields[this.FieldName];
            if (field == null)
            {
                return null;
            }
            
            return GetMediaItem(field);
        }

        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        private static string GetMediaItem(Field field)
        {
            MediaItem mediaItem = null;
            switch (field.TypeKey)
            {
                case "image":
                    var image = (ImageField)field;
                    if (image != null)
                    {
                        mediaItem = image.MediaItem;
                    }
                    break;
                case "general link":
                    var mediaLink = (LinkField)field;
                    
                    if (mediaLink != null)
                    {
                        if (mediaLink.IsInternal)
                        {
                            mediaItem = Database.GetDatabase("web").GetItem(mediaLink.TargetID);
                            return GetMediaUrl(mediaItem);
                        }
                        return mediaLink.Url;
                    }
                    break;
            }
            return GetMediaUrl(mediaItem);
        }

        private static string GetMediaUrl(MediaItem mediaItem)
        {
            if (mediaItem != null)
            {
                var options = new MediaUrlOptions
                {
                    AbsolutePath = false,
                    MediaLinkServerUrl = SiteContextFactory.GetSiteContext("advisers").HostName,
                    AlwaysIncludeServerUrl = true
                };
                return MediaManager.GetMediaUrl(mediaItem, options);
            }

            return null;
        }
    }
}

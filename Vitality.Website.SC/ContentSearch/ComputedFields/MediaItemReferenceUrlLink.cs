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

            MediaItem mediaItem = null;
            if (field.TypeKey == "image")
            {
                var image = (ImageField)field;
                if (image != null)
                {
                    mediaItem = image.MediaItem;
                }
            }
            else if (field.TypeKey == "general link")
            {
                var mediaLink = (LinkField)field;
                if (mediaLink != null)
                {
                    mediaItem = Database.GetDatabase("web").GetItem(mediaLink.TargetID);
                }
            }

            if (mediaItem != null)
            {
                var options = new MediaUrlOptions
                                  {
                                      AbsolutePath = false, 
                                      MediaLinkServerUrl = SiteContextFactory.GetSiteContext("presales").HostName,
                                      AlwaysIncludeServerUrl = true
                                  };
                return MediaManager.GetMediaUrl(mediaItem, options);
            }

            return null;
        }

        public string FieldName { get; set; }

        public string ReturnType { get; set; }
    }
}

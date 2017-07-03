namespace Vitality.Website.SC.ContentSearch.ComputedFields
{
    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.ComputedFields;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;

    public class MediaItemSize : AbstractComputedIndexField
    {
        public override object ComputeFieldValue(IIndexable indexable)
        {
            // item is currently being indexed.
            var indexableItem = indexable as SitecoreIndexableItem;

            if (indexableItem == null)
            {
                Log.Warn($"{this} : unsupported IIndexable type : {indexable.GetType()}", this);
                return null;
            }

            var field = indexableItem.Item.Fields["document"];

            if (field == null)
            {
                return null;
            }

            var media = GetMediaItem(field);
            return media != null ? (object)(media.Size / 1024) : null;
        }

        private static MediaItem GetMediaItem(Field field)
        {
            switch (field.TypeKey)
            {
                case "image":
                    return ((ImageField)field)?.MediaItem;
                case "general link":
                    var mediaLink = (LinkField)field;

                    return mediaLink == null
                        ? null
                        : Database.GetDatabase("web").GetItem(mediaLink.TargetID);

                default:
                    return null;
            }
        }
    }
}

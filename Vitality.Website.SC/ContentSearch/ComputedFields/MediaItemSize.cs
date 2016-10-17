﻿namespace Vitality.Website.SC.ContentSearch.ComputedFields
{
    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.ComputedFields;
    using Sitecore.Data;
    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Diagnostics;
    using Sitecore.Resources.Media;
    using Sitecore.Sites;

    public class MediaItemSize : AbstractComputedIndexField
    {
            public override object ComputeFieldValue(IIndexable indexable)
            {
                // item is currently being indexed.
                var indexableItem = indexable as SitecoreIndexableItem;

                if (indexableItem == null)
                {                                                                                                        
                    Log.Warn(string.Format("{0} : unsupported IIndexable type : {1}", this, indexable.GetType()), this);
                    return null;
                }

                var field = indexableItem.Item.Fields["document"];

                if (field == null) return null;

                var media = GetMediaItem(field);

                return media != null ? (object) (media.Size/1024) : null;
            }

        public string FieldName { get; set; }

        public string ReturnType { get; set; } 

        private static MediaItem GetMediaItem(Field field)
        {   
            switch (field.TypeKey)
            {
                case "image":
                    var image = (ImageField)field;
                    if (image != null)
                    {
                        return image.MediaItem;
                    }
                    break;
                case "general link":
                    var mediaLink = (LinkField)field;
                    if (mediaLink != null)
                    {
                        return Database.GetDatabase("web").GetItem(mediaLink.TargetID);
                    }
                    break;
            }
            return null;
        }
    }
}

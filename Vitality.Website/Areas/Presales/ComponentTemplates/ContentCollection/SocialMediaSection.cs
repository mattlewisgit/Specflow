using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection
{
    [SitecoreType(AutoMap = true)]
    public class SocialMediaSection :SitecoreItem
    {
        [SitecoreChildren]
        public IEnumerable<SocialMediaItem> SocialMediaItems { get; set; }
        [SitecoreField("__Sortorder")]
        public int SortOrder { get; set; }
    }
}
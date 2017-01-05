using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection
{
    [SitecoreType(AutoMap = true)]
    public class MpuSection : SitecoreItem
    {
        [SitecoreChildren]
        public IEnumerable<ImageLink> ImageLinks { get; set; }
        [SitecoreField("__Sortorder")]
        public int SortOrder { get; set; }
    }
}
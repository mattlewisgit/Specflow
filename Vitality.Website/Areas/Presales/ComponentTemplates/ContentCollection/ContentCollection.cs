using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.ComponentTemplates.Articles;
using Vitality.Website.Areas.Presales.ComponentTemplates.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection
{
    [SitecoreType(AutoMap = true)]
    public class ContentCollection : SitecoreItem
    {
        public string Headline { get; set; }
        public string OpeningParagraph { get; set; }
        public string LargeColumnSide { get; set; }

        [SitecoreQuery("./*[@@templateid='{A9C674A9-0C3A-4F6B-83DF-B0BD25E863E0}']", IsRelative = true)]
        public virtual IEnumerable<LargeArticle> LargeArticles { get; set; }

        [SitecoreQuery("./*[@@templateid='{ED92DF1A-DA76-40E7-9780-11011865968A}']", IsRelative = true)]
        public virtual IEnumerable<MediumArticle> MediumArticles { get; set; }

        [SitecoreQuery("./*[@@templateid='{E5A3E874-6E47-442B-B9A9-612CC96095ED}']", IsRelative = true)]
        public virtual IEnumerable<SmallArticle> SmallArticles { get; set; }

        [SitecoreQuery("./*[@@templateid='{6738ED7B-195F-4505-A289-D525C143E480}']", IsRelative = true)]
        public virtual IEnumerable<SocialMediaSection> SocialMediaSections { get; set; }

        [SitecoreQuery("./*[@@templateid='{4A3A387E-F7C7-4ACB-83C7-49706D77B6A9}']", IsRelative = true)]
        public virtual IEnumerable<MpuSection> MpuSections { get; set; }
    }
}
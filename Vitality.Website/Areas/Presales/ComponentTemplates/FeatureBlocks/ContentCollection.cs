using System.Collections.Generic;
using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.ComponentTemplates.ContentCollection;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    [SitecoreType(AutoMap = true)]
    public class ContentCollection : SitecoreItem
    {
        public string Headline { get; set; }
        public string OpeningParagraph { get; set; }
        public string LeftCss { get; set; }
        public string RightCss { get; set; }

        [SitecoreQuery("./*[@@templateid='{A9C674A9-0C3A-4F6B-83DF-B0BD25E863E0}']", IsRelative = true)]
        public virtual IEnumerable<LargeArticle> LargeArticles { get; set; }

        [SitecoreQuery("./*[@@templateid='{ED92DF1A-DA76-40E7-9780-11011865968A}']", IsRelative = true)]
        public virtual IEnumerable<MediumArticle> MediumArticles { get; set; }

        [SitecoreQuery("./*[@@templateid='{E5A3E874-6E47-442B-B9A9-612CC96095ED}']", IsRelative = true)]
        public virtual IEnumerable<SmallArticle> SmallArticles { get; set; }

        [SitecoreQuery("./*[@@templateid='{307FF875-5C27-45DA-9C14-6ADC774A9E82}']", IsRelative = true)]
        public virtual IEnumerable<SocialMedia> SocialMediaItems { get; set; }

        [SitecoreQuery("./*[@@templateid='{BDD88ED4-C40F-43A1-9900-572B18179434}']", IsRelative = true)]
        public virtual IEnumerable<ImageLink> ImageLinks { get; set; }
    }
}
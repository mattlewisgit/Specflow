using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    public class AwardLeader : SitecoreItem
    {
        public AwardLeader()
        {
            this.BackgroundImage = new Image();
        }

        public string LeadIn { get; set; }

        public string Headline { get; set; }

        public string OpeningParagraph { get; set; }

        public Image BackgroundImage { get; set; }

        [SitecoreChildren]
        public IEnumerable<ArticleItem> ArticleItems { get; set; }

        [SitecoreChildren]
        public IEnumerable<AwardLogo> AwardLogos { get; set; }
    }

    public class ArticleItem : SitecoreItem
    {
        public ArticleItem()
        {
            Image = new Image();
        }

        public Image Image { get; set; }

        public string LeadIn { get; set; }

        public string Title { get; set; }

        public Link Link { get; set; }
    }

    public class AwardLogo : SitecoreItem
    {
        public AwardLogo()
        {
            AwardImage = new Image();
        }
        public Image AwardImage { get; set; }

        public Link Link { get; set; }

    }
}
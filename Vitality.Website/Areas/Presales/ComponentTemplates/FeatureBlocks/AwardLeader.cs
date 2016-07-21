using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.ComponentTemplates.Generic;

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

        public IEnumerable<ArticleItem> GetArticleItems()
        {
            return GetChildren<ArticleItem>(Guid.Parse("972CA70E-945F-4D10-967B-FD622EF97D66"));
        }

        public IEnumerable<ImageLink> GetAwardLogos()
        {
            return GetChildren<ImageLink>(Guid.Parse("25EB72FE-6AE2-44E4-AC1E-9631E53D3AB0"));
        }
    }
}
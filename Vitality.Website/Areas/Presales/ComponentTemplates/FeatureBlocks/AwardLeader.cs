﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.ComponentTemplates.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    [SitecoreType(AutoMap = true)]
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

        [SitecoreQuery("./*[@@templateid='{972CA70E-945F-4D10-967B-FD622EF97D66}']", IsRelative = true)]
        public virtual IEnumerable<ArticleItem> ArticleItems { get; set; }

        [SitecoreQuery("./*[@@templateid='{25EB72FE-6AE2-44E4-AC1E-9631E53D3AB0}']", IsRelative = true)]
        public virtual IEnumerable<ImageLink> AwardLogos { get; set; }
    }
}
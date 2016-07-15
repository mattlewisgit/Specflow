using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}
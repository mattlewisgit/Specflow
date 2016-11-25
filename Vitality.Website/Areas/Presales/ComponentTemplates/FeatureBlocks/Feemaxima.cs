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
    [SitecoreType(AutoMap = true)]
    public class FeeMaxima : SitecoreItem
    {
        public string Headline { get; set; }

        public string BackLinkText { get; set; }

        public string SearchText { get; set; }

        public string SearchPlaceholderText { get; set; }
    }
}
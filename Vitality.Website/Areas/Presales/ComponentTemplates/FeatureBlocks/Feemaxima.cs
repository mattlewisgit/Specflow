using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Globalization;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.Areas.Presales.ComponentTemplates.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    [SitecoreType(AutoMap = true)]
    public class FeeMaxima : SitecoreItem
    {
        public FeeMaxima()
        {
            CurrencySymbol = "£";
        }
        public string AnaesthetistsFeeHeader { get; set; }
        public string BackLinkText { get; set; }
        public string ChapterText { get; set; }
        public string CodeHeader { get; set; }
        public string CurrencySymbol { get; set; }
        public string DescriptionHeader { get; set; }
        public string Headline { get; set; }
        public string NoResultsText { get; set; }
        public string SearchText { get; set; }
        public string SearchPlaceholderText { get; set; }
        public string SurgeonsFeeHeader { get; set; }
    }
}
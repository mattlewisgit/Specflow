using Glass.Mapper.Sc.Configuration.Attributes;
using Vitality.Website.Areas.Global.Models;
using Vitality.Website.SC.Utilities;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.FeatureBlocks
{
    [SitecoreType(AutoMap = true)]
    public class FeeMaxima : SitecoreItem
    {
        public FeeMaxima()
        {
            CurrencySymbol = DictionaryHelper.CurrencySymbol.Phrase;
        }
        public string AnaesthetistsFeeHeader { get; set; }
        public string BackLinkText { get; set; }
        public string ChapterText { get; set; }
        public string CodeHeader { get; set; }
        public string ChooseChapterText { get; set; }
        public string CurrencySymbol { get; set; }
        public string DescriptionHeader { get; set; }
        public string Headline { get; set; }
        public string LoadingText { get; set; }
        public string SearchText { get; set; }
        public string SearchPlaceholderText { get; set; }
        public string SurgeonsFeeHeader { get; set; }
    }
}
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class QuoteApplyFooterViewModel
    {
        public string CallToAction { get; set; }
        public string CallToActionText { get; set; }
        public string CallUsText { get; set; }
        public string ContactNumber { get; set; }
        public bool EnableProgressBar { get; set; }
        public string JoinUsText { get; set; }
        public Image LeftImage { get; set; }
        public Image MiddleImage { get; set; }
        public Image RightImage { get; set; }
        public bool IsFormAttached { get; set; }
        public string OpeningHoursText { get; set; }
    }
}

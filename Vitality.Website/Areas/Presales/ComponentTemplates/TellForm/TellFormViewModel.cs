using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.TellForm
{
    public class TellFormViewModel
    {
        public string CallToActionText { get; set; }
        public string ChildDobSeperatorLabel { get; set; }
        public string ChildDobLastLabel { get; set; }
        public string OkBtnText { get; set; }
        public string OkBtnHelpText { get; set; }
        public IEnumerable<QuestionGroupViewModel> QuestionGroups { get; set; }
        public string ServiceOutagePage { get; set; }
        public string TermsAndCondition { get; set; }
    }
}

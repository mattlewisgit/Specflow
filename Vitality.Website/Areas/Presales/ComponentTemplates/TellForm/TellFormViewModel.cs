using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.TellForm
{
    public class TellFormViewModel
    {
        public Dictionary<string, string> AdditionalData { get; set; }
        public string OkBtnText { get; set; }
        public string OkBtnHelpText { get; set; }
        public string PostAction { get; set; }
        public string RedirectTo { get; set; }
        public IEnumerable<QuestionGroupViewModel> QuestionGroups { get; set; }
        public string ServiceOutagePage { get; set; }
        public string TermsAndCondition { get; set; }
    }
}

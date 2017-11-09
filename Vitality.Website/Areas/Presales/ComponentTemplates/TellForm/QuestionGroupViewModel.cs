using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.TellForm
{
    public class QuestionGroupViewModel
    {
        public string BasedOnKey { get; set; }
        public string[] BasedOnValues { get; set; }
        public string Key { get; set; }
        public string HelpText { get; set; }
        public string Label { get; set; }
        public IEnumerable<QuestionViewModel> Questions { get; set; }
        public string ValidationMessage { get; set; }
        public bool IsHidden { get; set; }
        public bool QuestionTitleBreakLine { get; set; }
    }
}

using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
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
    }
}

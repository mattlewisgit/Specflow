using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.TellForm
{
    public class QuestionViewModel
    {
        public string ControlType { get; set; }
        public string Value { get; set; }
        public string Key { get; set; }
        public string Label { get; set; }
        public string Placeholder { get; set; }
        public List<KeyValuePair<string, string>> RelatedData { get; set; }
        public List<FieldValidatorViewModel> Validators { get; set; }
        public string Mask { get; set; }
        public string FieldSize { get; set; }
        public bool Breakline { get; set; }
        public string FieldAction { get; set; }

    }
}

using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.TellForm
{
    public class FieldValidatorViewModel
    {
        public bool IsAsync { get; set; }
        public Dictionary<string,string> Parameters { get; set; }
        public string ValidatorName { get; set; }
    }
}

using System.Collections.Specialized;

namespace Vitality.Website.Areas.Global.Models
{
    public class FieldValidator
    {
        public bool IsAsync { get; set; }
        public NameValueCollection Parameters { get; set; }
        public string ValidatorName { get; set; }
    }
}

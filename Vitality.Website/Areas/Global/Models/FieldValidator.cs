using System.Collections.Generic;
using System.Collections.Specialized;

namespace Vitality.Website.Areas.Global.Models
{
    public class FieldValidator
    {
        public string ValidatorName { get; set; }
        public NameValueCollection Parameters { get; set; }
    }
}

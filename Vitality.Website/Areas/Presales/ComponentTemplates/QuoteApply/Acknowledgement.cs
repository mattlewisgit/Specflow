using System.Collections.Specialized;
using Vitality.Website.Areas.Global.Models;
using Glass.Mapper.Sc.Fields;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class Acknowledgement : SitecoreItem
    {
        public NameValueCollection AdditionalData { get; set; }
        public Link CallToAction { get; set; }
        public string Message { get; set; }
    }
}

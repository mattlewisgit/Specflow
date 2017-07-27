using System.Collections.Specialized;
using Glass.Mapper.Sc.Fields;
using Vitality.Website.Areas.Global.Models;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class Acknowledgement : SitecoreItem
    {
        public NameValueCollection AdditionalData { get; set; }
        public Link CallToAction { get; set; }
        public string Message { get; set; }
    }
}

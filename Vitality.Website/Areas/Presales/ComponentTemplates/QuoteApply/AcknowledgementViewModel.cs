using System.Collections.Generic;

namespace Vitality.Website.Areas.Presales.ComponentTemplates.QuoteApply
{
    public class AcknowledgementViewModel
    {
        public Dictionary<string, string> AdditionalData { get; set; }
        public string CallToAction { get; set; }
        public string Message { get; set; }
    }
}

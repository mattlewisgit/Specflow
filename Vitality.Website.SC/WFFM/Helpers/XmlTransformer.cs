using System.Collections.Generic;
using System.Linq;

namespace Vitality.Website.SC.WFFM.Helpers
{
    internal static class XmlTransformer
    {
        internal static string TransformXml(string xml, Dictionary<string, string> fields)
        {
            return fields.Aggregate(xml, (current, field) => current.Replace(field.Key, field.Value));
        }
    }
}

using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Vitality.Website.App.Ccsd.Models
{
    public class ExternalCcsd
    {
        [DeserializeAs(Name = "ExternalCCSD")]
        public List<Chapter> Chapters { get; set; }
    }
}

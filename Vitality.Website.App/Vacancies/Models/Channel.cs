using System.Collections.Generic;
using System.Xml.Serialization;
using RestSharp.Deserializers;

namespace Vitality.Website.App.Vacancies.Models
{
    public class Channel
    {
        public string Description { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public List<Item> Vacancies { get; set; }
    }
}

using System.Collections.Generic;
using RestSharp.Deserializers;

namespace Vitality.Website.App.Vacancies.Models
{
    public class Channel
    {
        public string Description { get; set; }
        public string Link { get; set; }
        public string Title { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}

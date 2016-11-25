using System.Collections.Generic;

namespace Vitality.Website.App.Models.Feemaxima
{
    public class Section
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<Procedure> Procedures { get; set; }
    }
}

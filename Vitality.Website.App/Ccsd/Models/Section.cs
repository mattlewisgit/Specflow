using System.Collections.Generic;

namespace Vitality.Website.App.Ccsd.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Procedure> Procedures { get; set; }
    }
}

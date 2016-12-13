using System.Collections.Generic;

namespace Vitality.Website.App.Models.FeeMaxima
{
    public class Chapter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Section> Sections { get; set; }
    }
}

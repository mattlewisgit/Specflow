using System.Collections.Generic;

namespace Vitality.Website.App.Models.CCSD
{
    public class CcsdChapter
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<CcsdSection> CcsdSections { get; set; }
    }
}

using System.Collections.Generic;

namespace Vitality.Website.App.Models.CCSD
{
    public class CcsdSection
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<CcsdProcedure> CcsdProcedures { get; set; }
    }
}

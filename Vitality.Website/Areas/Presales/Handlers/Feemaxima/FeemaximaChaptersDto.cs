using System.Collections.Generic;
using Vitality.Website.App.Models.CCSD;

namespace Vitality.Website.Areas.Presales.Handlers.Feemaxima
{
    public class FeemaximaChaptersDto
    {
        public IEnumerable<CcsdChapter> CcsdChapters { get; set; }

        public static FeemaximaChaptersDto From(IEnumerable<CcsdChapter> ccsdChapters)
        {
            return new FeemaximaChaptersDto
            {
                CcsdChapters = ccsdChapters
            };
        }
    }
}
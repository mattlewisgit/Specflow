using System.Collections.Generic;
using Vitality.Website.App.Ccsd.Models;

namespace Vitality.Website.Areas.Presales.Handlers.FeeMaxima
{
    public class FeeMaximaChaptersDto
    {
        public IEnumerable<Chapter> Chapters { get; set; }

        public static FeeMaximaChaptersDto From(IEnumerable<Chapter> chapters)
        {
            return new FeeMaximaChaptersDto
            {
                Chapters = chapters
            };
        }
    }
}

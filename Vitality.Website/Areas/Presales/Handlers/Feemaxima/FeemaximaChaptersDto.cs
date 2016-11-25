using System.Collections.Generic;
using Vitality.Website.App.Models.Feemaxima;

namespace Vitality.Website.Areas.Presales.Handlers.Feemaxima
{
    public class FeemaximaChaptersDto
    {
        public IEnumerable<Chapter> Chapters { get; set; }

        public static FeemaximaChaptersDto From(IEnumerable<Chapter> chapters)
        {
            return new FeemaximaChaptersDto
            {
                Chapters = chapters
            };
        }
    }
}
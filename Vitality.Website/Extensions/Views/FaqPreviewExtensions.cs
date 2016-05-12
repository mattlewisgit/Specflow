using System.Collections.Generic;
using System.Linq;
using Glass.Mapper.Sc.Web.Mvc;
using Vitality.Website.Areas.Presales.Models.FAQ;

namespace Vitality.Website.Extensions.Views
{
    public static class FaqPreviewExtensions
    {
        public static IEnumerable<IGrouping<int, QuestionAnswer>> ModelBatches(this GlassView<FeaturedQuestions> view)
        {
            return view.Model.Questions.Select((x, i) => new { x, i }).GroupBy(p => (p.i / 2), p => p.x);
        }

    }
}
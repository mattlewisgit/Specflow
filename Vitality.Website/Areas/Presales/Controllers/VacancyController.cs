using System;
using MediatR;

using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Glass.Mapper.Sc;
using Vitality.Website.App.Vacancies.Models;
using Vitality.Website.Areas.Presales.Handlers.Vacancies;
using Vitality.Website.Areas.Presales.SettingsTemplates;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class VacancyController : BaseController
    {
        private readonly ISitecoreContext _sitecoreContext;

        public VacancyController(IMediator mediator, ISitecoreContext sitecoreContext) : base(mediator)
        {
            _sitecoreContext = sitecoreContext;
        }

        [HttpGet]
        [Route("api/Vacancy/List")]
        public HttpResponseMessage List(Guid settingsId)
        {
            var feedSettings = _sitecoreContext.GetItem<FeedSettings>(settingsId);
            return GetResponse<VacanciesRequest, VacanciesDto>(
                new VacanciesRequest(feedSettings), vacancies=>vacancies.Vacancies.Any());
        }
    }
}

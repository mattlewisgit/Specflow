using System;
using MediatR;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Vitality.Website.Areas.Presales.Handlers.Vacancies;

namespace Vitality.Website.Areas.Presales.Controllers
{
    public class VacancyController : BaseController
    {
        public VacancyController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("api/Vacancy/List")]
        public HttpResponseMessage List(Guid settingsId)
        {
            return GetResponse<VacanciesRequest, VacanciesDto>(
                new VacanciesRequest(settingsId), vacancies=>vacancies.Vacancies.Any());
        }
    }
}

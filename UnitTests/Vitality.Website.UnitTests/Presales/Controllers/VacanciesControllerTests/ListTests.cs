using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Glass.Mapper.Sc;
using Moq;
using Shouldly;
using Vitality.Website.App.Vacancies.Interfaces;
using Vitality.Website.App.Vacancies.Models;
using Vitality.Website.Areas.Presales.Controllers;
using Vitality.Website.Areas.Presales.Handlers.Vacancies;
using Vitality.Website.Areas.Presales.SettingsTemplates;
using Vitality.Website.UnitTests.TestDoubles;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Controllers.VacanciesControllerTests
{
    public class ListTests
    {
        private VacancyController _controller;
        private readonly Guid _feedSettingId;
        private readonly Mock<ISitecoreContext> _sitecoreContext;
        private readonly Mock<IVacancyService> _vacancyService;


        public ListTests()
        {
            _feedSettingId = Guid.NewGuid();
            _sitecoreContext = new Mock<ISitecoreContext>();
            _vacancyService = new Mock<IVacancyService>();
        }

        [Fact]
        public void Should_respond_404_not_found_when_no_vacancies_available()
        {
            _vacancyService.Setup(v => v.GetLatestVacancies(It.IsAny<FeedSettings>())).Returns(new List<Item>());
            Init();
            _controller.List(_feedSettingId).StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }

        [Fact]
        public void Should_respond_200_ok_when_vacancies_returned()
        {
            _vacancyService.Setup(c => c.GetLatestVacancies(It.IsAny<FeedSettings>())).Returns(new List<Item>
            {
                new Item { Title = "Developer" }
            });
            Init();
            _controller.List(_feedSettingId).StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Fact]
        public void Should_contain_vacancies_in_the_response_body()
        {
            _vacancyService.Setup(c => c.GetLatestVacancies(It.IsAny<FeedSettings>())).Returns(new List<Item>
            {
                new Item { Title = "Developer" }
            });
            Init();
            _controller.List(_feedSettingId).Content.ReadAsAsync<VacanciesDto>().Result.ShouldNotBeNull();
        }

        private void Init()
        {
            _sitecoreContext.Setup(m => m.GetItem<FeedSettings>(_feedSettingId, false,false)).Returns(new FeedSettings {Id=_feedSettingId});
            var handler = new MediatorStub<VacanciesRequest, VacanciesDto>(new VacanciesHandler(_sitecoreContext.Object, _vacancyService.Object));
           _controller = new VacancyController(handler);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Glass.Mapper.Sc;
using Moq;
using Vitality.Website.App.Vacancies.Interfaces;
using Vitality.Website.App.Vacancies.Models;
using Vitality.Website.Areas.Presales.Handlers.Vacancies;
using Vitality.Website.Areas.Presales.SettingsTemplates;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.Vacancies
{
    public class VacanciesHandlerTests
    {
        public class CallVacancyService
        {
            private static ObjectCache CacheStore = MemoryCache.Default;
            private readonly Mock<ISitecoreContext> _sitecoreContext;
            private readonly Mock<IVacancyService> _vacancyService;
            private readonly VacanciesHandler _handler;
            private readonly Guid _settingsId;

            public CallVacancyService()
            {
                _settingsId = Guid.NewGuid();
                _sitecoreContext = new Mock<ISitecoreContext>();
                _vacancyService = new Mock<IVacancyService>();
                _handler = new VacanciesHandler(_sitecoreContext.Object, _vacancyService.Object);
            }

            [Fact]
            public void should_return_vacancy_list_from_cache_when_found()
            {
                //Add the cache value only for 10 second only to be able to run the test
                CacheStore.Add(_settingsId + "_vacancies",
                    new VacanciesDto
                    {
                        Vacancies = new List<Item>
                        {
                            new Item {Advertid = 1}
                        }
                    }, DateTimeOffset.UtcNow.AddSeconds(10));
                _handler.Handle(new VacanciesRequest(_settingsId));
                _vacancyService.Verify(smc => smc.GetLatestVacancies(It.IsAny<FeedSettings>()), Times.Never);
                CacheStore.Remove(_settingsId + "_vacancies");
            }

            [Fact]
            public void should_return_vacancy_list_from_feed_when_not_found_in_cache()
            {
                _vacancyService.Setup(smc => smc.GetLatestVacancies(It.IsAny<FeedSettings>())).Returns(new List<Item> {new Item()});
                _handler.Handle(new VacanciesRequest(_settingsId));
                _vacancyService.VerifyAll();
            }
        }
    }
}
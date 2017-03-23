using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using Glass.Mapper.Sc;
using Moq;
using Vitality.Website.App.Ccsd.Interfaces;
using Vitality.Website.App.Ccsd.Models;
using Vitality.Website.Areas.Presales.Handlers.FeeMaxima;
using Vitality.Website.Areas.Presales.Handlers.Vacancies;
using Vitality.Website.Areas.Presales.SettingsTemplates;
using Xunit;

namespace Vitality.Website.UnitTests.Presales.Handlers.FeeMaxima
{
    public class FeeMaximaChaptersHandlerTests
    {
        public class CallCcsdService
        {
            private static readonly string _cacheKey = "_ccsdchapters";
            private static ObjectCache CacheStore = MemoryCache.Default;
            private readonly Mock<ISitecoreContext> _sitecoreContext;
            private readonly Mock<ICcsdService> _ccsdService;
            private readonly FeeMaximaChaptersHandler _handler;
            private readonly Guid _settingsId;

            public CallCcsdService()
            {
                _settingsId = Guid.NewGuid();
                _sitecoreContext = new Mock<ISitecoreContext>();
                _ccsdService = new Mock<ICcsdService>();
                _handler = new FeeMaximaChaptersHandler(_ccsdService.Object, _sitecoreContext.Object);
            }

            [Fact]
            public void should_return_vacancy_list_from_cache_when_found()
            {
                //Add the cache value only for 10 second only to be able to run the test
                CacheStore.Add(_settingsId + _cacheKey,
                    new FeeMaximaChaptersDto
                    {
                        Chapters = new List<Chapter>
                        {
                            new Chapter {Id = 1}
                        }
                    }, DateTimeOffset.UtcNow.AddSeconds(10));
                _handler.Handle(new FeeMaximaChaptersRequest(_settingsId));
                _ccsdService.Verify(smc => smc.GetChapters(It.IsAny<FeedSettings>()), Times.Never);
                CacheStore.Remove(_settingsId + _cacheKey);
            }

            [Fact]
            public void should_return_vacancy_list_from_feed_when_not_found_in_cache()
            {
                _ccsdService.Setup(smc => smc.GetChapters(It.IsAny<FeedSettings>()))
                    .Returns(new List<Chapter> {new Chapter()});
                _handler.Handle(new FeeMaximaChaptersRequest(_settingsId));
                _ccsdService.VerifyAll();
            }
        }
    }
}

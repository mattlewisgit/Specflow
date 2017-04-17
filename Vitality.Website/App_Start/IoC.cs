using Sitecore.DependencyInjection;
using Vitality.Website.App.Helpers;
using Vitality.Website.App.Vacancies;
using Vitality.Website.App.Vacancies.Interfaces;
namespace Vitality.Website.App_Start
{
    using App.Ccsd;
    using App.Ccsd.Interfaces;
    using Glass.Mapper.Sc;
    using MediatR;
    using SimpleInjector;
    using SimpleInjector.Diagnostics;
    using SimpleInjector.Integration.Web.Mvc;
    using SimpleInjector.Integration.WebApi;
    using Sitecore.ContentSearch;
    using Sitecore.Mvc.Helpers;
    using Sitecore.Pipelines;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using IDependencyResolver = System.Web.Mvc.IDependencyResolver;
    using Microsoft.Extensions.DependencyInjection;

    public class IoC : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            var serviceprovider = serviceCollection.BuildServiceProvider();

            serviceCollection.AddTransient<ISitecoreContext>(provider => SitecoreContext.GetFromHttpContext());
            serviceCollection.AddTransient<IMediator, Mediator>();
            serviceCollection.AddTransient<IVacancyService, VacancyService>();
            //var assemblies = new[] { Assembly.Load("Vitality.Website") };

            //container.Register<IMediator, Mediator>();
            //container.Register<SingleInstanceFactory>(() => type => container.GetInstance(type));
            //container.Register<MultiInstanceFactory>(() => type => container.GetAllInstances(type));
            //container.Register(typeof(IRequestHandler<,>), assemblies);
            //container.Register(typeof(INotificationHandler<>), assemblies);
            //container.RegisterPerWebRequest<ISitecoreContext>(() => SitecoreContext.GetFromHttpContext());
            //container.RegisterMvcControllers(assemblies);
            //RegisterWebApiControllers(assemblies);
            //container.Register<Func<string, IProviderSearchContext>>(() => index => ContentSearchManager.GetIndex(index).CreateSearchContext(), new WebApiRequestLifestyle());
            //container.Register<ICcsdService, CcsdService>();
            //container.Register<IMockDataHelper, MockDataHelper>();
            //container.Register<IVacancyService, VacancyService>();

            serviceCollection.AddMvcControllers("Vitality.Website*");
        }
    }
}

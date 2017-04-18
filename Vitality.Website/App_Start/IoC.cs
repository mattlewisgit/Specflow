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
            
            serviceCollection.AddTransient<IVacancyService, VacancyService>();
            serviceCollection.AddTransient<ICcsdService, CcsdService>();
            serviceCollection.AddTransient<IMockDataHelper, MockDataHelper>();
            serviceCollection.AddTransient<IVacancyService, VacancyService>();
            serviceCollection.AddMediatR();

            serviceCollection.AddScoped<SingleInstanceFactory>(p => t => p.GetService(t));
            serviceCollection.AddScoped<MultiInstanceFactory>(p => t => p.GetServices(t));
            
            //container.Register<Func<string, IProviderSearchContext>>(() => index => ContentSearchManager.GetIndex(index).CreateSearchContext(), new WebApiRequestLifestyle());


            serviceCollection.AddMvcControllers("Vitality.Website*");
        }
    }
}

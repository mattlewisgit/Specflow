using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.DependencyInjection;
using Vitality.Website.App.Helpers;
using Vitality.Website.App.Vacancies;
using Vitality.Website.App.Vacancies.Interfaces;
using Vitality.Website.Areas.Presales.Handlers.Literature;

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
            var assemblies = new[] { Assembly.Load("Vitality.Website") };
            
            serviceCollection.AddTransient(provider => SitecoreContext.GetFromHttpContext());
            
            serviceCollection.AddScoped<IVacancyService, VacancyService>();
            serviceCollection.AddScoped<ICcsdService, CcsdService>();
            serviceCollection.AddScoped<IMockDataHelper, MockDataHelper>();
            serviceCollection.AddScoped<IVacancyService, VacancyService>();
            
            serviceCollection.AddMediatR(assemblies);
            serviceCollection.AddScoped<SingleInstanceFactory>(p => t => p.GetService(t));
            serviceCollection.AddScoped<MultiInstanceFactory>(p => t => p.GetServices(t));

            serviceCollection.AddMvcControllers(assemblies);
        }
    }
}

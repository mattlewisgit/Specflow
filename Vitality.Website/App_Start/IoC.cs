using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.DependencyInjection;
using Vitality.Website.Areas.Presales.Services;

namespace Vitality.Website.App_Start
{
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
            serviceCollection.AddScoped<IPresalesBslService, PresalesBslService>();

            serviceCollection.AddMediatR(assemblies);
            serviceCollection.AddScoped<SingleInstanceFactory>(p => t => p.GetService(t));
            serviceCollection.AddScoped<MultiInstanceFactory>(p => t => p.GetServices(t));

            //serviceCollection.AddMvcControllers(assemblies);
        }
    }
}

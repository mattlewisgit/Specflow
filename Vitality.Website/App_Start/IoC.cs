using Vitality.Website.App.Helpers;
using Vitality.Website.App.Vacancies;
using Vitality.Website.App.Vacancies.Interfaces;
using Vitality.Website.Areas.Presales.Services;

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

    public class IoC
    {
        private static Container container;

        public void Process(PipelineArgs args)
        {
            container = new Container();

            RegisterDepenencies();

            DependencyResolver.SetResolver(new SimpleInjectorSitecoreDependencyResolver(new SimpleInjectorDependencyResolver(container)));

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegisterDepenencies()
        {
            var assemblies = new [] { Assembly.Load("Vitality.Website") };

            container.Register<IMediator, Mediator>();
            container.Register<SingleInstanceFactory>(() => type => container.GetInstance(type));
            container.Register<MultiInstanceFactory>(() => type => container.GetAllInstances(type));
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.Register(typeof(INotificationHandler<>), assemblies);
            container.Register(typeof(IAsyncRequestHandler<,>), assemblies);
            container.Register(typeof(IAsyncNotificationHandler<>), assemblies);
            container.RegisterPerWebRequest<ISitecoreContext>(() => SitecoreContext.GetFromHttpContext());
            container.RegisterMvcControllers(assemblies);
            RegisterWebApiControllers(assemblies);
            container.Register<Func<string, IProviderSearchContext>>(() => index => ContentSearchManager.GetIndex(index).CreateSearchContext(), new WebApiRequestLifestyle());
            container.Register<IPresalesBslService, PresalesBslService>();
        }

        /// <remarks>
        /// Unable to use container.RegisterWebApiControllers(GlobalConfiguration.Configuration, vitalityWebsite)
        /// due to Sitecore Api Controllers being picked up which have multiple public constructors.
        /// </remarks>
        private static void RegisterWebApiControllers(IEnumerable<Assembly> assemblies)
        {
            foreach (var type in assemblies.SelectMany(assembly => assembly.DefinedTypes))
            {
                if (typeof(ApiController).IsAssignableFrom(type))
                {
                    Registration registration = Lifestyle.Transient.CreateRegistration(type, container);

                    registration.SuppressDiagnosticWarning(
                        DiagnosticType.DisposableTransientComponent,
                        "Web API registers controllers for " +
                            "disposal when the request ends during the call to ApiController.ExecuteAsync.");

                    container.AddRegistration(type, registration);
                }
            }
        }

        private class SimpleInjectorSitecoreDependencyResolver : IDependencyResolver
        {
            private readonly IDependencyResolver _innerDependencyResolver;

            public SimpleInjectorSitecoreDependencyResolver(IDependencyResolver innerDependencyResolver)
            {
                _innerDependencyResolver = innerDependencyResolver;
            }

            public object GetService(Type serviceType)
            {
                try
                {
                    return _innerDependencyResolver.GetService(serviceType);
                }
                catch (Exception)
                {
                    return TypeHelper.CreateObject<IController>(serviceType);
                }
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return _innerDependencyResolver.GetServices(serviceType);
            }
        }
    }
}

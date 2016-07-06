using System;
using System.Collections.Generic;

namespace Vitality.Website.App_Start
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;

    using Glass.Mapper.Sc;

    using MediatR;

    using SimpleInjector;
    using SimpleInjector.Diagnostics;
    using SimpleInjector.Integration.Web.Mvc;
    using SimpleInjector.Integration.WebApi;

    using Sitecore.ContentSearch;
    using Sitecore.Mvc.Helpers;
    using Sitecore.Pipelines;
    using Sitecore.Services.Infrastructure.Sitecore.Controllers;

    using Vitality.Website.Areas.Presales.Controllers;

    using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

    public class IoC
    {
        private static Container _container;

        public static Container Container { get { return _container; } }

        public void Process(PipelineArgs args)
        {
            _container = new Container();
            
            //_container.RegisterWebApiControllers(GlobalConfiguration.Configuration, exeAssem);

            Registration registration = Lifestyle.Transient.CreateRegistration(typeof(LiteratureLibraryController), _container);
            //if (typeof(ApiController).IsAssignableFrom(type))
            registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Web API registers controllers for disposal when the request ends during the call to ApiController.ExecuteAsync.");
            _container.AddRegistration(typeof(LiteratureLibraryController), registration);

            _container.Register(() => ContentSearchManager.GetIndex("literature_library").CreateSearchContext(), new WebApiRequestLifestyle());

            RegisterDepenencies();

            DependencyResolver.SetResolver(new SimpleInjectorSitecoreDependencyResolver(new SimpleInjectorDependencyResolver(_container)));

            _container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(_container);
        }

        private static void RegisterDepenencies()
        {
            var executingAssembly = new [] { Assembly.GetExecutingAssembly() };

            _container.Register<IMediator, Mediator>();
            _container.Register<SingleInstanceFactory>(() => type => _container.GetInstance(type));
            _container.Register<MultiInstanceFactory>(() => type => _container.GetAllInstances(type));
            _container.Register(typeof(IRequestHandler<,>), executingAssembly);
            _container.Register(typeof(INotificationHandler<>), executingAssembly);
            _container.RegisterPerWebRequest<ISitecoreContext>(() => SitecoreContext.GetFromHttpContext());
            _container.RegisterMvcControllers(executingAssembly);
        }

        private class SimpleInjectorSitecoreDependencyResolver : IDependencyResolver
        {
            private readonly IDependencyResolver innerDependencyResolver;

            public SimpleInjectorSitecoreDependencyResolver(IDependencyResolver innerDependencyResolver)
            {
                this.innerDependencyResolver = innerDependencyResolver;
            }

            public object GetService(Type serviceType)
            {
                try
                {
                    return this.innerDependencyResolver.GetService(serviceType);
                }
                catch (Exception)
                {
                    return TypeHelper.CreateObject<IController>(serviceType);
                }
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return this.innerDependencyResolver.GetServices(serviceType);
            }
        }
    }
}
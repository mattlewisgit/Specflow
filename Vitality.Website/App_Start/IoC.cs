using System;
using System.Collections.Generic;

namespace Vitality.Website.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using Glass.Mapper.Sc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;

    using Sitecore.Mvc.Helpers;
    using Sitecore.Pipelines;

    using IDependencyResolver = System.Web.Mvc.IDependencyResolver;

    public class IoC
    {
        private static Container _container;

        public static Container Container { get { return _container; } }

        public void Process(PipelineArgs args)
        {
            _container = new Container();

            RegisterDepenencies();

            DependencyResolver.SetResolver(new SimpleInjectorSitecoreDependencyResolver(new SimpleInjectorDependencyResolver(_container)));

            _container.Verify();
        }

        private static void RegisterDepenencies()
        {
            _container.RegisterPerWebRequest<ISitecoreContext>(() => SitecoreContext.GetFromHttpContext());
            _container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
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
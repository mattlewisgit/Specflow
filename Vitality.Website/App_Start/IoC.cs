using Sitecore.DependencyInjection;
using Vitality.Website.Areas.Presales.Services;

namespace Vitality.Website.App_Start
{
    using Glass.Mapper.Sc;
    using MediatR;
    using System.Reflection;
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

            serviceCollection.AddMvcControllers(assemblies);
        }
    }
}

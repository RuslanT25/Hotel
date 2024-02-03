using Autofac;
using Hotel.WebApi.Services.WebApiServices;

namespace Hotel.WebApi.Services.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var serviceTypes = new Type[]
            {
        typeof(StaffApiService)
            };

            foreach (var serviceType in serviceTypes)
            {
                builder.Register(c =>
                {
                    var clientFactory = c.Resolve<IHttpClientFactory>();
                    return Activator.CreateInstance(serviceType, clientFactory);
                }).As(serviceType).InstancePerLifetimeScope();

            }
        }

    }
}

using Autofac;
using Hotel.WebApi.Services.WebApiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.WebApi.Services.DependencyResolvers.Autofac
{
    public class AutofacWebApiServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var serviceTypes = new Type[]
            {
        typeof(StaffApiService),
        typeof(ServiceApiService),
        typeof(TestimonialApiService),
        typeof(AboutApiService),
        typeof(RoomApiService),
        typeof(SubscribeApiService)
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

using Hotel.DAL.ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.DependencyResolvers
{
    public static class DbContextServiceInjection
    {
        public static IServiceCollection AddDbContextService(this IServiceCollection services)
        {
            ServiceProvider provider = services.BuildServiceProvider();
            IConfiguration configuration = provider.GetService<IConfiguration>();
            services.AddDbContextPool<HotelDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyCon")).UseLazyLoadingProxies());

            return services;
        }
    }
}

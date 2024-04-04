
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hotel.Business.DependencyResolvers;
using Hotel.Business.DependencyResolvers.Autofac;
using Hotel.DAL.ApplicationContext;
using Hotel.Entity.Mapper;
using Hotel.Entity.Models;
using Hotel.Web.DependencyResolvers.ValidationRegistration;
using Hotel.WebApi.Services.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Identity;

namespace Hotel.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacWebApiServiceModule());
                });

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                });

            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Services.AddAutoMapper(typeof(MapProfile));
            builder.Services.AddAllValidators();

            builder.Services.AddDbContextService();

            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<HotelDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireUppercase = true;
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.LoginPath = "/admin/Login/Index";
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");

            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                  name: "admin",
                  pattern: "{area:exists}/{controller=AdminLayout}/{action=Index}/{id?}"
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
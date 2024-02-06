using Autofac.Extensions.DependencyInjection;
using Autofac;
using Hotel.Business.DependencyResolvers;
using Hotel.Business.DependencyResolvers.Autofac;
using Hotel.Entity.Mapper;

namespace Hotel.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContextService(); // DbContextServiceInjection-daki metodu elave edirem.

            // Register AutofacBusinessModule
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>    
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                });

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("HotelApi", opts =>
                {
                    opts.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            builder.Services.AddAutoMapper(typeof(MapProfile));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("HotelApi");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
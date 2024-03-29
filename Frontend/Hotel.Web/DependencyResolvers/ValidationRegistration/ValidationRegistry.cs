﻿using FluentValidation;

namespace Hotel.Web.DependencyResolvers.ValidationRegistration
{
    public static class ValidationRegistry
    {
        public static IServiceCollection AddAllValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<Validations.Staff.StaffValidator>();
            services.AddValidatorsFromAssemblyContaining<Validations.About.AboutValidator>();
            services.AddValidatorsFromAssemblyContaining<Validations.Room.RoomValidator>();
            services.AddValidatorsFromAssemblyContaining<Validations.Service.ServiceValidator>();
            services.AddValidatorsFromAssemblyContaining<Validations.Staff.StaffValidator>();

            return services;
        }
    }
}

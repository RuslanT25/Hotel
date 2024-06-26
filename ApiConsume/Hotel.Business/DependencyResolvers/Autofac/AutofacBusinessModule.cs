﻿using Autofac;
using Microsoft.Extensions.Configuration;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Business.ManagerServices.Concretes;
using Hotel.DAL.Contracts;
using Hotel.DAL.Implementations;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RoomManager>().As<IRoomService>().SingleInstance();
            builder.RegisterType<RoomRepository>().As<IRoomRepository>().SingleInstance();

            builder.RegisterType<ServiceManager>().As<IServiceService>().SingleInstance();
            builder.RegisterType<ServiceRepository>().As<IServiceRepository>().SingleInstance();

            builder.RegisterType<StaffManager>().As<IStaffService>().SingleInstance();
            builder.RegisterType<StaffRepository>().As<IStaffRepository>().SingleInstance();

            builder.RegisterType<TestimonialManager>().As<ITestimonialService>().SingleInstance();
            builder.RegisterType<TestimonialRepository>().As<ITestimonialRepository>().SingleInstance();

            builder.RegisterType<SubscribeManager>().As<ISubscribeService>().SingleInstance();
            builder.RegisterType<SubscribeRepository>().As<ISubscribeRepository>().SingleInstance();

            builder.RegisterType<AboutManager>().As<IAboutService>().SingleInstance();
            builder.RegisterType<AboutRepository>().As<IAboutRepository>().SingleInstance();

            builder.RegisterType<BookingManager>().As<IBookingService>().SingleInstance();
            builder.RegisterType<BookingRepository>().As<IBookingRepository>().SingleInstance();

            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<ContactRepository>().As<IContactRepository>().SingleInstance();

            builder.RegisterType<SendMessageManager>().As<ISendMessageService>().SingleInstance();
            builder.RegisterType<SendMessageRepository>().As<ISendMessageRepository>().SingleInstance();

            builder.RegisterType<EmailManager>().As<IEmailService>().SingleInstance();
        }
    }
}

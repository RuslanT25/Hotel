using AutoMapper;
using Hotel.Entity.DTOs.About;
using Hotel.Entity.DTOs.Booking;
using Hotel.Entity.DTOs.Contact.Inbox;
using Hotel.Entity.DTOs.Contact.SendMessage;
using Hotel.Entity.DTOs.Login;
using Hotel.Entity.DTOs.Register;
using Hotel.Entity.DTOs.Room;
using Hotel.Entity.DTOs.Service;
using Hotel.Entity.DTOs.Staff;
using Hotel.Entity.DTOs.Subscribe;
using Hotel.Entity.DTOs.Testimonial;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;

namespace Hotel.Entity.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<RoomPostDTO, Room>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertToBytes(src.ImageFile)))
                .ReverseMap();
            CreateMap<Room, RoomGetPutDTO>().ReverseMap();

            CreateMap<Service, ServicePostDTO>().ReverseMap();
            CreateMap<Service, ServiceGetPutDTO>().ReverseMap();

            CreateMap<StaffPostDTO, Staff>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertToBytes(src.ImageFile)))
                .ReverseMap();
            CreateMap<Staff, StaffGetPutDTO>().ReverseMap();

            CreateMap<About, AboutPostDTO>().ReverseMap();
            CreateMap<About, AboutPutDTO>().ReverseMap();

            CreateMap<TestimonialPostDTO, Testimonial>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => ConvertToBytes(src.ImageFile)))
                .ReverseMap();
            CreateMap<Testimonial, TestimonialGetPutDTO>().ReverseMap();

            CreateMap<Subscribe, SubscribePostDTO>().ReverseMap();
            CreateMap<Subscribe, SubscribeGetPutDTO>().ReverseMap();

            CreateMap<Booking, BookingPostDTO>().ReverseMap();
            CreateMap<Booking, BookingGetPutDTO>().ReverseMap();

            CreateMap<AppUser, RegisterPostDTO>().ReverseMap();
            CreateMap<AppUser, LoginPostDTO>().ReverseMap();

            CreateMap<Contact, ContactPostDTO>().ReverseMap();
            CreateMap<Contact, ContactGetDTO>().ReverseMap();

            CreateMap<SendMessage, SendMessagePostDTO>().ReverseMap();
            CreateMap<SendMessage, SendMessageGetDTO>().ReverseMap();
        }

        private byte[] ConvertToBytes(IFormFile imageFile)
        {
            if (imageFile == null)
                return null;

            using var memoryStream = new MemoryStream();
            imageFile.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
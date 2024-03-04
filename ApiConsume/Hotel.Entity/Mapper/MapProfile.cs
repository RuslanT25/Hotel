using AutoMapper;
using Hotel.Entity.DTOs.About;
using Hotel.Entity.DTOs.Register;
using Hotel.Entity.DTOs.Room;
using Hotel.Entity.DTOs.Service;
using Hotel.Entity.DTOs.Staff;
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

            CreateMap<Service,ServicePostDTO>().ReverseMap();
            CreateMap<Service,ServiceGetPutDTO>().ReverseMap();

            CreateMap<Staff,StaffPostDTO>().ReverseMap();
            CreateMap<Staff,StaffGetPutDTO>().ReverseMap();

            CreateMap<AppUser,RegisterPostDTO>().ReverseMap();

            CreateMap<About,AboutPostDTO>().ReverseMap();
            CreateMap<About,AboutPutDTO>().ReverseMap();
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

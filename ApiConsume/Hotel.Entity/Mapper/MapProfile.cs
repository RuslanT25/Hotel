﻿using AutoMapper;
using Hotel.Entity.DTOs.About;
using Hotel.Entity.DTOs.Register;
using Hotel.Entity.DTOs.Room;
using Hotel.Entity.DTOs.Service;
using Hotel.Entity.DTOs.Staff;
using Hotel.Entity.Models;

namespace Hotel.Entity.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Room, RoomPostDTO>().ReverseMap();
            CreateMap<Room,RoomGetPutDTO>().ReverseMap();

            CreateMap<Service,ServicePostDTO>().ReverseMap();
            CreateMap<Service,ServiceGetPutDTO>().ReverseMap();

            CreateMap<Staff,StaffPostDTO>().ReverseMap();
            CreateMap<Staff,StaffGetPutDTO>().ReverseMap();

            CreateMap<AppUser,RegisterPostDTO>().ReverseMap();

            CreateMap<About,AboutPostDTO>().ReverseMap();
            CreateMap<About,AboutPutDTO>().ReverseMap();
        }
    }
}

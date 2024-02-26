using AutoMapper;
using Hotel.Entity.DTOs.Room;
using Hotel.Entity.DTOs.Service;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Room, RoomPostDTO>().ReverseMap();

            CreateMap<Service,ServicePostDTO>().ReverseMap();
            CreateMap<Service,ServiceGetPutDTO>().ReverseMap();
        }
    }
}

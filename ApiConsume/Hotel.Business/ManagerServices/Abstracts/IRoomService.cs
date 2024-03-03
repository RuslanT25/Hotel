using Hotel.Business.Results;
using Hotel.Entity.DTOs.Room;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Abstracts
{
    public interface IRoomService : IBaseService<Room>
    {
        Task<Result> AddRoomWithImageAsync(Room room, IFormFile image);
    }
}

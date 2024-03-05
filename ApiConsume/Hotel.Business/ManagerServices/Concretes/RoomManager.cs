using Hotel.Business.Constants;
using Hotel.Business.ManagerServices.Abstracts;
using Hotel.Business.Results;
using Hotel.DAL.Contracts;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class RoomManager : BaseManager<Room>, IRoomService
    {
        readonly IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository) : base(roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Result> AddRoomWithImageAsync(Room room, IFormFile image)
        {
            if (image.Length > 500000) // 500KB limit
            {
                return new ErrorResult("Image size cannot be more than 500KB.");
            }

            var allowedContentTypes = new[] { "image/jpeg", "image/png", "image/jpg" };
            if (!allowedContentTypes.Contains(image.ContentType))
            {
                return new ErrorResult("Invalid image format. Only .jpg and .png formats are allowed.");
            }

            await _roomRepository.AddRoomWithImageAsync(room, image);
            return new SuccessResult(Messages<Room>.Entity<Room>.Add());
        }
    }
}

using Hotel.Business.ManagerServices.Abstracts;
using Hotel.DAL.Contracts;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Entities;
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
    }
}

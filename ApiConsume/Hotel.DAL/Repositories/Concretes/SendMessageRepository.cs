using Hotel.DAL.ApplicationContext;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Concretes
{
    public class SendMessageRepository : GenericRepository<SendMessage>, ISendMessageRepository
    {
        readonly HotelDbContext _context;
        public SendMessageRepository(HotelDbContext context) : base(context)
        {
            _context = context;
        }

        public int GetSendMessageCount()
        {
            int count = _context.SendMessages.Count();

            return count;
        }
    }
}

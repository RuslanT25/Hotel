using Hotel.DAL.ApplicationContext;
using Hotel.DAL.Contracts;
using Hotel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Implementations
{
    public class SubscribeRepository : GenericRepository<Subscribe>, ISubscribeRepository
    {
        public SubscribeRepository(HotelDbContext dbContext) : base(dbContext)
        {

        }
    }
}

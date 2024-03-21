using Hotel.DAL.ApplicationContext;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Repositories.Concretes
{
    public class AboutRepository : GenericRepository<About>, IAboutRepository
    {
        public AboutRepository(HotelDbContext dbContext) : base(dbContext)
        {
        }
    }
}

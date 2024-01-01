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
    public class ServiceDal : GenericDal<Service>, IServiceDal
    {
        public ServiceDal(HotelDbContext dbContext) : base(dbContext)
        {
        }
    }
}

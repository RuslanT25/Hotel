using Hotel.DAL.ApplicationContext;
using Hotel.DAL.Contracts;
using Hotel.DAL.Repositories.Abstracts;
using Hotel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.DAL.Implementations
{
    public class TestimonialRepository : GenericRepository<Testimonial>, ITestimonialRepository
    {
        public TestimonialRepository(HotelDbContext dbContext) : base(dbContext)
        {
        }
    }
}

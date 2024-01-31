using Hotel.Business.ManagerServices.Abstracts;
using Hotel.DAL.Contracts;
using Hotel.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Business.ManagerServices.Concretes
{
    public class TestimonialManager : BaseManager<Testimonial>, ITestimonialService
    {
        readonly ITestimonialRepository _testimonialRepository;
        public TestimonialManager(ITestimonialRepository testimonialRepository) : base(testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }
    }
}

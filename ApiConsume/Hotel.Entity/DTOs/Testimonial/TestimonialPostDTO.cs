using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.DTOs.Testimonial
{
    public class TestimonialPostDTO : TestimonialBaseDTO
    {
        public IFormFile? ImageFile { get; set; }
    }
}

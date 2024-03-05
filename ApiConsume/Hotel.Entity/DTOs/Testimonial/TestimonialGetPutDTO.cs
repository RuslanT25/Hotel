using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.DTOs.Testimonial
{
    public class TestimonialGetPutDTO : TestimonialBaseDTO
    {
        public int Id { get; set; }
        public byte[]? Image { get; set; }
    }
}

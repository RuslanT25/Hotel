using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Entity.Entities
{
    public class Testimonial : BaseEntity
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
    }
}

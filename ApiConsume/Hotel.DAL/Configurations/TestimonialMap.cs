using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Entity.Models;

namespace Hotel.DAL.Configurations
{
    public class TestimonialMap : BaseMap<Testimonial>, IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            Property(x => x.Name).HasColumnName("Commentor name");
        }
    }
}

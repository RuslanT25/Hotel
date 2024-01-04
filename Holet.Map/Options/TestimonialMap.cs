using Hotel.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holet.Map.Options
{
    public class TestimonialMap : BaseMap<Testimonial>
    {
        public override void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name)
                .HasColumnName("Commenter name")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Image)
                .HasColumnName("Commenter image");
        }
    }
}

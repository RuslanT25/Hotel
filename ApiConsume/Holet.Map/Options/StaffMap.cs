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
    public class StaffMap : BaseMap<Staff>
    {
        public override void Configure(EntityTypeBuilder<Staff> builder)
        {
            base.Configure(builder);
            builder.Property(x=>x.Name)
                .HasColumnName("Employee name")
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}

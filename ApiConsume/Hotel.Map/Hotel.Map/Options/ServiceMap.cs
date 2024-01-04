using Hotel.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Map.Options
{
    public class ServiceMap : BaseMap<Service>
    {
        public override void Configure(EntityTypeBuilder<Service> builder)
        {
            base.Configure(builder); // BaseMap'in Configure metodunu işledir.
            builder.Property(x => x.Icon)
                .HasColumnName("Icon image");
        }
    }
}

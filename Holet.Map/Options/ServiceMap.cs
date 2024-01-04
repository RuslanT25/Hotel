using Hotel.Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holet.Map.Options
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

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
    public class ServiceMap : BaseMap<Service>, IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            Property(x => x.Icon).HasColumnName("Icon image");
        }
    }
}

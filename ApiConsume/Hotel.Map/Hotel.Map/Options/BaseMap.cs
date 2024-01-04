using Hotel.Entity.Entities;
using Hotel.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Map.Options
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.CreatedDate).HasColumnName("Created time");
            builder.Property(x => x.ModifiedDate).HasColumnName("Updated time");
            builder.Property(x => x.DeletedDate).HasColumnName("Deleted time");
        }
    }
}

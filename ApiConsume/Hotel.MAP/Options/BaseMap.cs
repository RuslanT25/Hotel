using Hotel.Entity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.MAP.Options
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        protected BaseMap()
        {
            Property(x => x.CreatedDate).HasColumnName("Created Time");
            Property(x => x.DeletedDate).HasColumnName("Deleted Time");
            Property(x => x.ModifiedDate).HasColumnName("Updated Time");
        }
    }
}

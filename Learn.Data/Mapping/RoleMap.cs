using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.Data.Mapping
{
    public class RoleMap : EntityTypeConfiguration<Role>
    {
        public RoleMap()
        {
            this.HasKey(c => c.RoleId);
            this.Property(c => c.RoleName).HasMaxLength(64).IsRequired();
            this.Property(c => c.RoleDepId).IsRequired();
        }

    }




}

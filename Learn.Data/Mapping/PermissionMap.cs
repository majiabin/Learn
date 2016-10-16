using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.Data.Mapping
{
   public class PermissionMap:EntityTypeConfiguration<Permission>
    {
       public PermissionMap()
       {
           this.HasKey(c => c.PerId);
           this.Property(c => c.PerActionName).HasMaxLength(64);
           this.Property(c => c.PerAreaName).HasMaxLength(64);
           this.Property(c => c.PerContorllerName).HasMaxLength(64);
           this.Property(c => c.PerFormMethod).HasMaxLength(64);
           this.Property(c => c.PerIco).HasMaxLength(254);
           this.Property(c => c.PerJsMethodName).HasMaxLength(64);
           this.Property(c => c.PerName).HasMaxLength(64);
           this.Property(c => c.PerRemark).HasMaxLength(1024);
       }
    }
}

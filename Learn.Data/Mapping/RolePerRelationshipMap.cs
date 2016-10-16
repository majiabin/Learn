using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.Data.Mapping
{
    public class RolePerRelationshipMap: EntityTypeConfiguration<RolePerRelationship>
    {
        public RolePerRelationshipMap()
        {
            
            ToTable("RolePerRelationship");
            this.HasKey(c => c.RpId);
            this.HasRequired(c => c.Role).WithMany(c => c.RolePerRelationships).HasForeignKey(c => c.RprRoleId);
            this.HasRequired(c => c.Permission).WithMany(c => c.RolePerRelationships).HasForeignKey(c => c.RprPerId);

        }
    }
}

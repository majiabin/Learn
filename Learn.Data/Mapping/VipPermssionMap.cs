using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.Data.Mapping
{
    public class VipPermssionMap : EntityTypeConfiguration<VipPermssion>
    {
        public VipPermssionMap()
        {
            ToTable("VipPermssion");
            this.HasKey(c => c.VpId);
            this.HasRequired(c => c.Employee).WithMany(c => c.VipPermssions).HasForeignKey(c => c.VpUId).WillCascadeOnDelete(false);
            this.HasRequired(c => c.Permission).WithMany(c => c.VipPermssions).HasForeignKey(c => c.VpPId).WillCascadeOnDelete(false);
        }
    }
}

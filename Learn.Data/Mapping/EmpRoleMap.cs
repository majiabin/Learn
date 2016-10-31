using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;


namespace Learn.Data.Mapping
{
    public class EmpRoleMap : EntityTypeConfiguration<EmpRoleRelationship>
    {
        public EmpRoleMap()
        {
            ToTable("EmpRoleRelationship");

            this.HasKey(c => c.ErId);
            //WillCascadeOnDelete：不使用级联删除
            HasRequired(pt => pt.Employee).WithMany(p => p.EmpRoleRealationships).HasForeignKey(pt => pt.ErUId).WillCascadeOnDelete(false);
            HasRequired(pt => pt.Role).WithMany(t => t.EmpRoleRealationships).HasForeignKey(pt => pt.ErRId).WillCascadeOnDelete(false);
        }
    }
}

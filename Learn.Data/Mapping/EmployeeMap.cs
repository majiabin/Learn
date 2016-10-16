using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.Data.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            this.HasKey(c => c.EmpId);
            this.Property(c => c.EmpAddress).HasMaxLength(512);
            this.Property(c => c.EmpCellPhone).HasMaxLength(16);
            this.Property(c => c.EmpCnName).HasMaxLength(64);
            this.Property(c => c.EmpLoginName).HasMaxLength(64).IsRequired();
            this.Property(c => c.EmpPhone).HasMaxLength(16);
            this.Property(c => c.EmpLoginPwd).HasMaxLength(32).IsRequired();
            this.Property(c => c.EmpIsDel).IsRequired();



        }


    }
}

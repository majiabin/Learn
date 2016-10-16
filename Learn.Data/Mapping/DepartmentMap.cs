using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.Data.Mapping
{
   public class DepartmentMap:EntityTypeConfiguration<Department>
    {
       public DepartmentMap()
       {
           this.HasKey(c => c.DepId);
            //不使用级联删除
           this.HasMany(c => c.Employees).WithRequired(o => o.Department).HasForeignKey(o => o.EmpDepId).WillCascadeOnDelete(false);
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    public partial class Role
    {

        public int RoleId { get; set; }
        public int RoleDepId { get; set; }
        public string RoleName { get; set; }
        public bool RoleIsDel { get; set; }
        public DateTime RoleAddTime { get; set; }

        public virtual ICollection<EmpRoleRelationship> EmpRoleRealationships { set; get; }
        public virtual ICollection<RolePerRelationship> RolePerRelationships { set; get; }


    }
}

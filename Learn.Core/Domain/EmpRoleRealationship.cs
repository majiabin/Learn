using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    public class EmpRoleRealationship
    {
        /// <summary>
        /// 员工角色中间表id
        /// </summary>
        public int ErId { get; set; }
        /// <summary>
        /// 员工id
        /// </summary>
        public int ErUId { get; set; }
        /// <summary>
        /// 角色id
        /// </summary>
        public int ErRId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}

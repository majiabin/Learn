using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    public partial class EmpRoleRelationship
    {
        #region  此处由T4自动生成

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

        #endregion
        public virtual Employee Employee { get; set; }
        public virtual Role Role { get; set; }
    }
}

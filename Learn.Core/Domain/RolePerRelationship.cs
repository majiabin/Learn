using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    public partial class RolePerRelationship
    {
        #region 此处由T4自动生成
        //public int RpId { get; set; }
        //public int RprRoleId { get; set; }
        //public int RprPerId { get; set; }
        #endregion


        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}

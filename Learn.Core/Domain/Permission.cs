using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    /// <summary>
    /// 权限
    /// </summary>
    public partial class Permission
    {


        public int PerId { get; set; }
        /// <summary>
        /// 父id
        /// </summary>
        public int PerParent { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PerName { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string PerRemark { get; set; }

        public string PerAreaName { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string PerContorllerName { get; set; }
        /// <summary>
        /// 动作名称
        /// </summary>
        public string PerActionName { get; set; }
        public string PerFormMethod { get; set; }
        /// <summary>
        /// 操作类型 是get还是post
        /// </summary>
        public int PerOperationType { get; set; }
        /// <summary>
        /// js方法名称
        /// </summary>
        public string PerJsMethodName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string PerIco { get; set; }
        /// <summary>
        /// 是否是链接
        /// </summary>
        public bool PerIsLink { get; set; }
        public int PerOrder { get; set; }
        public bool PerIsShow { get; set; }
        public bool PerIsDel { get; set; }
        public DateTime PerAddTime { get; set; }


        public virtual ICollection<RolePerRelationship> RolePerRelationships { set; get; }
        public virtual ICollection<VipPermssion> VipPermssions { get; set; }
    }
}

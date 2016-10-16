using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employee
    {

        /// <summary>
        /// 员工id
        /// </summary>
        public int EmpId { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public int EmpDepId { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        public string EmpCnName { get; set; }
        /// <summary>
        /// 登陆名称
        /// </summary>
        public string EmpLoginName { get; set; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string EmpLoginPwd { get; set; }
        /// <summary>
        /// 姓别
        /// </summary>
        public bool EmpSex { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public bool EmpAge { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string EmpCellPhone { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string EmpPhone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string EmpAddress { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool EmpIsDel { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime EmpAddTime { get; set; }
        public virtual ICollection<EmpRoleRealationship> EmpRoleRealationships { set; get; }
        public virtual ICollection<VipPermssion> VipPermssions { get; set; }
        public virtual Department Department { get; set; }
       

    }
}

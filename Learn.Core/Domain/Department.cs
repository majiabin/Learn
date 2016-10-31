using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    /// <summary>
    /// 部门
    /// </summary>
    public partial class Department
    {
        #region 此处由T4自动生成

        //public int DepId { get; set; }
        //public string DepNames { get; set; }
        //public string DepRemark { get; set; }
        //public bool DepIsDel { get; set; }
        //public DateTime DepAddTime { get; set; }

        #endregion
        public ICollection<Employee> Employees { get; set; }
    }
}

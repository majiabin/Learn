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

        public int DepId { get; set; }
        public string DepNames { get; set; }
        public string DepRemark { get; set; }
        public bool DepIsDel { get; set; }
        public DateTime DepAddTime { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}

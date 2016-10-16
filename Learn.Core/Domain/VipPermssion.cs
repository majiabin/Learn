using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    /// <summary>
    /// 特权中间表
    /// </summary>
    public class VipPermssion
    {
        public int VpId { get; set; }
        public int VpUId { get; set; }
        public int VpPId { get; set; }

        public Employee Employee { get; set; }
        public Permission Permission { get; set; }


    }
}

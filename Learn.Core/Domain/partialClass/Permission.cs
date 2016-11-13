using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    public partial class Permission
    {
        public TreeNode ToNode()
        {
            return new TreeNode()
            {
                id = this.PerId,
                text = this.PerName,
                attributes = new
                {
                    url = "/" + this.PerAreaName + "/" + this.PerContorllerName + "/" + this.PerActionName,
                    isLink = this.PerIsLink
                },
                @checked = false,
                state = "open"
            };
        }
    }
}

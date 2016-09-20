using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.IService;

namespace Learn.Service
{
    public class RoleService:IRoleService
    {
        public string GetName()
        {
             return "name";
        }
    }
}

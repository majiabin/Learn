using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.IService
{
   public partial interface IEmployeeService:IBaseService<Employee>
    {
        int Login(string userName,string userPwd);
        List<Permission> GetUserPerssion(int userId);
    }
}

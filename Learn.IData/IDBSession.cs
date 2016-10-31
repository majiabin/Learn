using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.IData
{
    public partial interface IDBSession
    {

       # region 此处有T4自动生成

        //IDepartmentRepository DepartmentRepository { get; }
        //IRoleRepository RoleRepository { get; }
        //IEmployeeRepository EmployeeRepository { get; }
        //IPermissionRepository PermissionRepository { get; }

     # endregion
        int SaveChanges();
    }
}

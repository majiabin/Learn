using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.IData
{
    public interface IDBSession
    {
        IDepartmentRepository DepartmentRepository { get; }
        IRoleRepository RoleRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        int SaveChanges();
    }
}

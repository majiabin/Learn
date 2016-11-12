using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;
using Learn.IData;
using Learn.IService;

namespace Learn.Service
{
    public partial class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public int Login(Employee model)
        {
            Employee employee = dbSession.EmployeeRepository.Where(
                item => item.EmpLoginName == model.EmpLoginName && item.EmpLoginPwd == model.EmpLoginPwd)
                .FirstOrDefault();
            if (employee != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
    }
}

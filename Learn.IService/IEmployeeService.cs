using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.IService
{
   public interface IEmployeeService:IBaseService<Employee>
    {
       int Login(Employee model);
    }
}

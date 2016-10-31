using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;
using Learn.IService;

namespace Learn.Service
{
    public partial class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public int Login(Employee model)
        {
            var res = dbSession.EmployeeRepository.GetList(
                c => c.EmpLoginName == model.EmpLoginName && c.EmpLoginPwd == model.EmpLoginPwd).FirstOrDefault();
            if (res == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public List<Permission> GetUserPermissions(int uId)
        {

            return null;
        }

        #pragma region 此处有T4自动生成
        //public override void SetCurrentDal()
        //{
        //    CurrentService = dbSession.EmployeeRepository;
        //}
        #pragma endregion



    }
}

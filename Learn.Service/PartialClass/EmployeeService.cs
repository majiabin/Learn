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
        public int Login(string userName, string userPwd)
        {
            Employee employee = dbSession.EmployeeRepository.Where(
                item => item.EmpLoginName == userName && item.EmpLoginPwd == userPwd)
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

        public List<Permission> GetUserPerssion(int userId)
        {
            //根据用户id查找角色id集合
            List<int> roleIds = dbSession.EmpRoleRelationshipRepository.Where(item => item.ErUId == userId)
                 .Select(item => item.ErRId)
                 .ToList();
            //根据角色id查找权限id集合
            List<int> perssionIds = dbSession.RolePerRelationshipRepository.Where(item => roleIds.Contains(item.RprRoleId))
                  .Select(item => item.RprPerId)
                  .ToList();
            //根据用户id查找特权id集合
            List<int> vipInts = dbSession.VipPermssionRepository.Where(item => item.VpUId == userId).Select(item => item.VpPId).ToList();
            //合并
            vipInts.ForEach(vipPerssion =>
            {
                if (!perssionIds.Contains(vipPerssion))
                {
                    perssionIds.Add(vipPerssion);
                }
            });
            //查询权限表的权限
            return dbSession.PermissionRepository.Where(item => perssionIds.Contains(item.PerId)).ToList();
        }
    }
}

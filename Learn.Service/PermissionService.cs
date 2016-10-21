using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;
using Learn.IService;

namespace Learn.Service
{
   public class PermissionService:BaseService<Permission>,IPermissionService
    {
       public override void SetCurrentDal()
       {
           CurrentService = dbSession.PermissionRepository;
       }
    }
}

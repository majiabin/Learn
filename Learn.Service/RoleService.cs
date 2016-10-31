using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;
using Learn.IService;

namespace Learn.Service
{
    public partial class RoleService : BaseService<Role>, IRoleService
    {
    #pragma region 此处有T4自动生成

        //public override void SetCurrentDal()
        //{
        //    CurrentService = dbSession.RoleRepository;
        //}

    #pragma endregion
    }

}

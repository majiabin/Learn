using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;
using Learn.DataFactory;
using Learn.IData;
using Learn.IService;

namespace Learn.Service
{
   public  partial class UserInfoService:BaseService<UserInfo>,IUserInfoService
   {

       // private IDBSession dbSession = DBSessionContextFactory.GetSession();
        public override void SetCurrentDal()
       {
           CurrentService = dbSession.UserInfoRepository;
       }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;
using Learn.IData;

namespace Learn.Data
{
   public class UserInfoRepository:BaseRepository<UserInfo>,IUserInfoRepository
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.IData
{
    public interface IDBSession
    {
        IUserInfoRepository UserInfoRepository { get; }

        int SaveChanges();
    }
}

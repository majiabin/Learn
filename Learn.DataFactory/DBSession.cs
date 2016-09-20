using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Data;
using Learn.Data.Context;
using Learn.IData;

namespace Learn.DataFactory
{
    public class DBSession : IDBSession
    {
        public IUserInfoRepository UserInfoRepository
        {
            get { return new UserInfoRepository(); }
        }

        public int SaveChanges()
        {
            IDbContext dbContext = ContextFactory.GetContext();
            return dbContext.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Learn.Data;
using Learn.IData;

namespace Learn.DataFactory
{
    public class DBSessionContextFactory
    {
        public static IDBSession GetSession()
        {
            IDBSession dbSession = CallContext.GetData("dbSession") as IDBSession;
            if (dbSession == null)
            {
                dbSession = new DBSession();
                CallContext.SetData("dbSession", dbSession);
            }
            return dbSession;
        }
    }


}

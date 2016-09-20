using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Learn.IData;

namespace Learn.Data.Context
{
    public class ContextFactory
    {
        public static IDbContext GetContext()
        {
            IDbContext context = CallContext.GetData("learnContext") as IDbContext;
            if (context == null)
            {
                context = new LearnContext();
                CallContext.SetData("learnContext", context);
            }
            return context;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learn.Web.Helper
{
    public class BaseController : Controller
    {
        public OperationContext OperCur
        {
            get { return OperationContext.Current; }
        }

    }
}
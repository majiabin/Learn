using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learn.Web.Filter;

namespace Learn.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilter(GlobalFilterCollection filters)
        {
            //出册全局 权限检查 过滤器
            filters.Add(new CheckPermissionAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Learn.IService;
using Learn.Web.Helper;

namespace Learn.Web.Filter
{
    /// <summary>
    /// 自定义授权过滤器
    /// </summary>
    public class CheckPermissionAttribute : AuthorizeAttribute
    {
        public CheckPermissionAttribute()
        {

        }

        private IEmployeeService employeeService;
        public CheckPermissionAttribute(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

     

        private OperationContext opeCur = new OperationContext();
        /// <summary>
        /// 授权方法 -再次检查权限
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //1.检查是否登陆
            if (IsLogin())
            {
                //2.检查登陆用户是否有 访问当前url的权限
            }
            else   
            {
                //没有登陆
                filterContext.Result = opeCur.JsMsg("你没有登陆", "/Login/Index");
            }

        }


        #region 是否登陆

        private bool IsLogin()
        {
            //1.先判断是否有session
            if (opeCur.UserNow == null)
            {
                //1.1如果没有，则检查登陆cookie是否存在
                //1.1.1如果没有，登陆cookie，则代表用户没有登陆，直接返回false
                if (opeCur.UserId <= -1)
                {
                    return false;
                }
                //1.1.2如果没有cookie，则根据cookie里的登陆用户id，重新查询 登陆用户实体，并存入session
                else
                {
                    var usrId = opeCur.UserId;
                    opeCur.UserNow = employeeService.GetList(o => o.EmpId == usrId).SingleOrDefault();
                }
            }
            return true;
        }

        #endregion

    }
}
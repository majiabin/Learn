using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Learn.IService;
using Learn.Web.Attrs;
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


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            int i = 0;
            return true;
        }
        private OperationContext opeCur = new OperationContext();



        /// <summary>
        /// 授权方法 -再次检查权限
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!IsDefined<SkipLoginAttribute>(filterContext))
            {
                //1.检查是否登陆
                if (IsLogin())
                {
                    //2.检查登陆用户是否有 访问当前url的权限
                    filterContext.Result = opeCur.JsMsg("你没有登陆", "/Learn.Web/Manage/Index");
                }
                else
                {
                    //没有登陆
                    filterContext.Result = opeCur.JsMsg("你没有登陆", "/Learn.Web/Admin/Login");
                }
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

        #region 跳过

        /// <summary>
        /// 检查 过滤器上下文 中的当前被请求的方法 和 控制器是否贴有标签
        /// </summary>
        /// <typeparam name="AttrType"></typeparam>
        /// <param name="filterContext"></param>
        /// <returns></returns>
        public bool IsDefined<AttrType>(AuthorizationContext filterContext)
        {
            Type attrTypeObj = typeof(AttrType);
            return filterContext.ActionDescriptor.IsDefined(attrTypeObj, false)
                 || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(attrTypeObj, false);
        }

        #endregion

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using Learn.IService;
using Learn.Service;
using Learn.Web.Attrs;
using Learn.Web.Helper;

namespace Learn.Web.Filter
{
    /// <summary>
    /// 自定义授权过滤器
    /// </summary>
    public class CheckPermissionAttribute : AuthorizeAttribute
    {
       
        private EmployeeService employeeService=new EmployeeService() ;

     
        private OperationContext opeCur = new OperationContext();

        private List<string> listArea = new List<string>() {"admin"}; 

        /// <summary>
        /// 授权方法 -再次检查权限
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RouteData.DataTokens.ContainsKey("area"))
            {
                //后去当前请求区域名称
                string areaName = filterContext.RouteData.DataTokens["area"].ToString().ToLower();
                if (listArea.Contains(areaName))
                {
                    if (!IsDefined<SkipLoginAttribute>(filterContext))
                    {
                        //1.检查是否登陆
                        if (IsLogin())
                        {
                            if (!IsDefined<SkipPermissionAttrbute>(filterContext))
                            {
                                //2.检查登陆用户是否有 访问当前url的权限
                                if (!opeCur.HasPermission(areaName,filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,filterContext.ActionDescriptor.ActionName,opeCur.Request.HttpMethod))
                                {
                                    //没有登陆
                                    filterContext.Result = opeCur.JsMsg("您没有进行此项操作的权限", "/Admin/Login/Index");
                                }
                                else  //如果有权限
                                {
                                    //LoadMenuBtns(filterContext);
                                }

                            }
                            else   //跳过权限检查后
                            {
                                //LoadMenuBtns(filterContext);
                            }
                        }
                        else //没有登陆
                        {
                            filterContext.Result = opeCur.JsMsg("你没有登陆", "/Admin/Login/Index");
                        }
                    }
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
                    opeCur.UserNow = employeeService.Where(o => o.EmpId == usrId).SingleOrDefault();
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
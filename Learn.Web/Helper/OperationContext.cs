using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using System.Web.WebPages;
using Learn.Common;
using Learn.Core.Domain;

namespace Learn.Web.Helper
{
    public class OperationContext
    {
        #region Http 各种属性 的便捷访问

        public HttpContext HttpContext
        {
            get { return HttpContext.Current; }
        }


        public HttpResponse Response
        {
            get { return HttpContext.Response; }
        }

        public HttpRequest Request
        {
            get { return HttpContext.Request; }
        }

        public HttpSessionState Session
        {
            get { return HttpContext.Session; }
        }


        #endregion

        #region 操作cookie中的登陆用户id  +int UserId

        public int UserId
        {
            set
            {
                HttpCookie cookie = new HttpCookie("uInfo", value.ToString());
                cookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(cookie);
            }
            get
            {
                HttpCookie cookie = Request.Cookies["uInfo"];
                if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                {
                    return cookie.Value.ToString().AsInt();
                }
                else
                {
                    return -1;
                }
            }
        }

        #endregion

        #region 操作Session中的登录用户对象 Employee UsrNow
        public Employee UserNow
        {
            get { return (Employee)Session["userInfo"]; }
            set { Session["userInfo"] = (Employee)value; }
        }
        #endregion

        #region 返回js提示 和 跳转

        public ActionResult JsMsg(string strMsg, string strBackUrl = "")
        {
            StringBuilder sbJs = new StringBuilder("<script>alert(\"").Append(strMsg).Append("\");");
            if (!strBackUrl.IsNullOrEmpty())
            {
                sbJs.Append("window.location=\"").Append(strBackUrl).Append("\";");
            }
            sbJs.Append("</script>");
            return new ContentResult()
            {
                Content = sbJs.ToString()
            };
        }

        #endregion

        public bool HasPermission(string strAreaName, string strControllerName, string strActionName, string strFormMethod)
        {

            return true;
        }


    }
}
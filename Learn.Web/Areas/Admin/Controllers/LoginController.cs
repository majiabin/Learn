using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learn.Core.Domain;
using Learn.IService;
using Learn.Web.Attrs;
using Learn.Web.Helper;

namespace Learn.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        // GET: Controllers/Login
        private IEmployeeService employeeService;
        private OperationContext operationContext = new OperationContext();
        public LoginController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [SkipLogin]
        // GET: Login
        public ActionResult Index()
        {
            
            return View("Index");
        }

        [SkipLogin]
        public ActionResult Login(string empLoginName, string empLoginPwd, string autoLogin)
        {
            int num = employeeService.Login(empLoginName, empLoginPwd);
            if (num > 0)
            {
                Employee res = employeeService.Where(
              c => c.EmpLoginName == empLoginName && c.EmpLoginPwd == empLoginPwd).FirstOrDefault();
                Session["userInfo"] = res;
                ViewBag.Message = "登陆成功";
                if (autoLogin != null)
                {
                    HttpCookie httpCookie = new HttpCookie("uInfo", res.EmpId.ToString());
                    httpCookie.Expires = DateTime.Now.AddDays(7);
                    Response.Cookies.Add(httpCookie);
                }
                operationContext.UserPerssion = employeeService.GetUserPerssion(res.EmpId);
                return Content("ok");
            }
            else
            {
                ViewBag.Message = "用户或密码错误";
                return Content("no");
            }

        }
    }

}
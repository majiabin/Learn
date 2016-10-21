using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learn.Core.Domain;
using Learn.IService;
using Learn.Service;

namespace Learn.Web.Controllers
{
    public class LoginController : Controller
    {
        private IEmployeeService employeeService;
        public LoginController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Login(Employee model,string AutoLogin)
        {
            int num = employeeService.Login(model);
            if (num > 0)
            {
                Employee res = employeeService.GetList(
              c => c.EmpLoginName == model.EmpLoginName && c.EmpLoginPwd == model.EmpLoginPwd).FirstOrDefault();
                Session["userInfo"] = res;
                ViewBag.Message = "登陆成功";
                HttpCookie httpCookie = new HttpCookie("uInfo", model.EmpId.ToString());
                httpCookie.Expires = DateTime.Now.AddDays(7);
                Response.Cookies.Add(httpCookie);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "用户或密码错误";
            }
            return View("index");
        }
    }
  
}
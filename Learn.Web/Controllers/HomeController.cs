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
    public class HomeController : Controller
    {

        private IUserInfoService userInfoService;
     

        public HomeController(IRoleService roleService, IUserInfoService userInfoService)
        {
            this.userInfoService = userInfoService;
        }

        // GET: Home
        public ActionResult Index()
        {
           List<UserInfo> list= userInfoService.GetList(c=>c.Name=="zhangsan").ToList();
            return View("Index");
        }
    }
}
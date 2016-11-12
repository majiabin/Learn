using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learn.IService;

namespace Learn.Web.Areas.Admin.Controllers
{
    public class UserInfoController : Controller
    {
        private IDepartmentService departmentService;
        public UserInfoController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }

        // GET: Admin/UserInfo
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
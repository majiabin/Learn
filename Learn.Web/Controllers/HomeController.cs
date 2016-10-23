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

        private IRoleService roleService;
        private IDepartmentService departmentService;


        public HomeController(IRoleService roleService, IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
            this.roleService = roleService;
        }

        // GET: Home
        public ActionResult Index()
        {
            // List<Department> lis=   departmentService.GetList(c => true).ToList();
            return Redirect("/admin/");
            //return View("Index");
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using Learn.IService;

namespace Learn.Web.Areas.Admin.Controllers
{
    public class ManageController : Controller
    {
        private IPermissionService permissionService;
        public ManageController(IPermissionService permissionService)
        {
            this.permissionService = permissionService;
        }


        // GET: Admin/Manage
        public ActionResult Index()
        {
            return View("Index");
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMenu()
        {
            return null;
        }
    }
}
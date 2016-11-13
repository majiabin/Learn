using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using Learn.Core;
using Learn.Core.Domain;
using Learn.IService;
using Learn.Web.Attrs;
using Learn.Web.Helper;

namespace Learn.Web.Areas.Admin.Controllers
{
    public class ManageController : BaseController
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
           int aa= EnumHelper.OperationType.MENU;
            //从登录用户的 Session中 查询 菜单类型的权限集合
            List<Permission> menuList = OperCur.UserPerssion.FindAll(item => item.PerOperationType == EnumHelper.OperationType.MENU);
            // 将 菜单权限集合 转成 TreeNode 节点 树结构
            TreeNode rootNode = permissionService.Where(item => item.PerParent == 0).SingleOrDefault().ToNode();
            //根据根节点 对应 的 权限id，查询其所有的子节点
            rootNode.children = GetChildNode(menuList, rootNode.id);
            return Content("[" + OperCur.ToJson(rootNode) + "]");
        }


        #region 递归 生成 子节点 集合

        private List<TreeNode> GetChildNode(List<Permission> menuList, int parentId)
        {
            List<TreeNode> chileNodes = null;

            foreach (Permission menu in menuList)
            {
                if (menu.PerParent == parentId)
                {
                    if (chileNodes == null)
                    {
                        chileNodes = new List<TreeNode>();
                    }
                    // //将子权限 转成 子节点
                    TreeNode chiNode = menu.ToNode();
                    //将子节点 加入 子节点集合
                    chileNodes.Add(chiNode);
                    GetChildNode(menuList, chiNode.id);
                }
            }
            return chileNodes;
        }

        #endregion

    }
}
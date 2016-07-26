using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.WebSite.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IMenuService _menuService;
        private readonly IRoleService _roleService;

        public HomeController(IMenuService menuService,IRoleService roleService)
        {
            _menuService = menuService;
            _roleService = roleService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BackGroundIndex()
        {
            var user=(UserSessionDto)Session["UserBase"];

            var roleMenu = (List<MenuModel>) Session["RoleMenu"];
            if (roleMenu == null)
            {
                 roleMenu= _roleService.GetRoleMenuByRoleId(user.RoleId);
                //后面改为放缓存
                 Session["RoleMenu"] = roleMenu;
            }

            ViewBag.RoleMenu = roleMenu;
            return View();
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LoginOut()
        {
            Session["UserBase"] = null;
            Session["RoleMenu"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
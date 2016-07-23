using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class RoleController : BaseController
    {
        IRoleService roleService;
        IMenuService menuService;
        public RoleController(IRoleService rService, IMenuService mService)
        {
            roleService = rService;
            menuService = mService;
        }

        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            var list = roleService.GetPagerRole(string.Empty, page, rows).Select(_ => new
            {
                RoleID = _.RoleID,
                RoleName = _.RoleName,
                Remark = _.Remark,
                SortID = _.SortID
            });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.Menu = menuService.GetPagerMenu(string.Empty, 1, 1000);
            return View();
        }

        [HttpPost]
        public JsonResult Create(RoleModel roleModel, List<string> chkMenu, int SortID)
        {
            try
            {
                List<RoleMenuModel> roleMenu = new List<RoleMenuModel>();
                foreach (var id in chkMenu)
                    if (!string.IsNullOrEmpty(id))
                        roleMenu.Add(new RoleMenuModel() { MenuID = Convert.ToInt32(id), CreateID = null, CreateName = "", CreateTime = DateTime.Now });
                // TODO: Add insert logic here
                var result = roleService.InsertSingleRole(roleModel, roleMenu);
                var flag = result.Status == MessageStatus.Success ? true : false;
                var msg = result.Message;
                return Json(new { flag = flag, msg = msg });
            }
            catch (Exception ex)
            {
                return Json(new MessageModel() { Status = MessageStatus.Exception, Message = ex.Message });
            }
        }

        public ActionResult Edit(int id)
        {
            var model = roleService.GetRoleById(id);
            ViewBag.HMenu = model.Menu.Select(_ => _.MenuID);
            ViewBag.Menu = menuService.GetPagerMenu(string.Empty, 1, 1000);
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Edit(RoleModel roleModel, List<string> chkMenu, int SortID)
        {
            try
            {
                List<RoleMenuModel> roleMenu = new List<RoleMenuModel>();
                foreach (var id in chkMenu)
                    if (!string.IsNullOrEmpty(id))
                        roleMenu.Add(new RoleMenuModel() { MenuID = Convert.ToInt32(id), CreateID = null, CreateName = "", CreateTime = DateTime.Now });
                // TODO: Add insert logic here
                var result = roleService.UpdateSingleRole(roleModel);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new MessageModel() { Status = MessageStatus.Exception, Message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = roleService.DeleteSingleRole(id);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}
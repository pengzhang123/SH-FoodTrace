using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class MenuController : BaseController
    {
        IMenuService menuService;
        public MenuController(IMenuService mService)
        {
            menuService = mService;
        }
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            int count = menuService.GetMenuCount();
            string menuName = RequestHelper.RequestPost("menuName", string.Empty);
            var list = menuService.GetPagerMenu(menuName, page, rows).Select(_ => new
            {
                MenuID = _.MenuID,
                Name = _.Name,
                ParentID = _.ParentID,
                SortID = _.SortID,
                FunctionURL = _.FunctionURL
            });
            
            return Json(new { total=count,rows=list}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var list = menuService.GetPagerMenu(string.Empty, 1, 100).OrderBy(_ => _.SortID).ToList();
            List<SelectListItem> itemList = new List<SelectListItem>();
            list.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.Name, Value = m.MenuID.ToString() });
            });
            itemList.Insert(0, new SelectListItem() { Text = "顶级分类", Value = "0" });
            ViewBag.MenuList = itemList;
            return PartialView(new MenuModel());
        }

        [HttpPost]
        public ActionResult Create(MenuModel model)
        {
            var result = menuService.InsertSingleMenu(model);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var model = menuService.GetMenuById(id);
            //var list = menuService.GetPagerMenu(string.Empty, 1, 100).OrderBy(_ => _.SortID).ToList();
            //List<SelectListItem> itemList = new List<SelectListItem>();
            //list.ForEach(m =>
            //{
            //    itemList.Add(new SelectListItem() { Text = m.Name, Value = m.MenuID.ToString() });
            //});
            //itemList.Insert(0, new SelectListItem() { Text = "顶级分类", Value = "0" });
            //ViewBag.MenuList = itemList;
            return PartialView(model);
        }

        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public JsonResult GetMenuByMenuType(int type)
        {
            var result = new ResultJson();
            try
            {
                var list = menuService.GetPagerMenu(string.Empty, 1, 100).OrderBy(_ => _.SortID).Where(s => s.Flag == type && s.ParentID == 0).ToList();
                List<SelectListItem> itemList = new List<SelectListItem>();
                list.ForEach(m =>
                {
                    itemList.Add(new SelectListItem() { Text = m.Name, Value = m.MenuID.ToString() });
                });
                itemList.Insert(0, new SelectListItem() { Text = "顶级分类", Value = "0" });
                result.Data = itemList;
                result.IsSuccess = true;

            }
            catch (Exception)
            {
                
                throw;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Edit(MenuModel model)
        {
            var result = menuService.UpdateSingleMenu(model);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = menuService.DeleteSingleMenu(id);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteMenu(string ids)
        {
            var result = menuService.DeletMenuByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
        /// <summary>
        /// 获取所有菜单列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRoleMenuTree()
        {
            var list = menuService.GetPagerMenu(string.Empty, 1, 100).Select(_ => new
            {
                id = _.MenuID,
                name = _.Name,
                pId = _.ParentID
            });
            return Json(list);
        }

        public JsonResult GetMenuTree(int flag)
        {
            var result = new ResultJson();
            try
            {
                var data = menuService.GetMenuTreeList(flag);
                result.IsSuccess = true;
                result.Data = data;
            }
            catch (Exception)
            {
                
                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMenuByRoleId(int roleId)
        {
            return Json(true);
        }
    }
}
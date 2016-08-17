using FoodTrace.Common.Libraries;
using FoodTrace.Common.Log;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease.Activities;

namespace FoodTrace.WebSite.Controllers
{
    public class RoleController : BaseController
    {
        IRoleService roleService;
        IMenuService menuService;
        private readonly IUserRoleService _userRoleService;
        public RoleController(IRoleService rService, IMenuService mService,IUserRoleService userRoleService)
        {
            roleService = rService;
            menuService = mService;
            _userRoleService = userRoleService;
        }

        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            var count = roleService.GetRoleCount();
            string roleName = RequestHelper.RequestPost("roleName", string.Empty);
            var list = roleService.GetPagerRole(roleName, page, rows).Select(_ => new
            {
                RoleID = _.RoleID,
                RoleName = _.RoleName,
                Remark = _.Remark,
                SortID = _.SortID
            });
            return Json(new{total=count,rows=list}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            //ViewBag.Menu = menuService.GetPagerMenu(string.Empty, 1, 1000);
            return View();
        }

        [HttpPost]
        public JsonResult Create(RoleModel roleModel)
        {
            try
            {
                // TODO: Add insert logic here
                var result = roleService.InsertSingleRole(roleModel);
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
            //ViewBag.RoleMenu =roleService.GetMenuListByRoleId(id) ;
            //ViewBag.Menu = menuService.GetPagerMenu(string.Empty, 1, 1000);
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Edit(RoleModel roleModel)
        {
            ResultJson result=new ResultJson();
            try
            {
                
                 roleService.UpdateSingleRole(roleModel);
                result.IsSuccess = true;
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

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeletRole(string ids)
        {
            var result = roleService.DeleteRolesByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
        /// <summary>
        /// 设置角色菜单权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ActionResult SetRoleMenu(int roleId)
        {
            ViewBag.RoleId = roleId;
            return View();
        }

        /// <summary>
        /// 保存角色关联页面数据
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="menuId"></param>
        /// <param name="chkStatus"></param>
        /// <returns></returns>
        public JsonResult SaveRoleRefMenu(int roleId, List<int> chkMenu,int flag)
        {
            var result = new ResultJson();
            try
            {
                List<RoleMenuModel> roleMenu = new List<RoleMenuModel>();
                if (chkMenu != null && chkMenu.Count>0)
                {
                    foreach (var id in chkMenu)
                    {
                      
                        roleMenu.Add(new RoleMenuModel() { MenuID = id, CreateID = null, CreateName = "", CreateTime = DateTime.Now });

                    }

                }
                roleService.UpdateRoleMenu(roleId, roleMenu,flag);
                //_roleApp.SaveRoleRefMenu(roleId, menuId, chkStatus);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                //log4netHelper.Exception(ex.Message);
            }
            return Json(result);
        }

        /// <summary>
        /// 获取用户关联角色
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public JsonResult GetUserRoleByUid(int uid)
        {
            var result =new ResultJson();
            try
            {
                var role = _userRoleService.GetUserRefRoleByUid(uid).Select(s => s.RoleID);
                result.Data = role;
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
               Logger.Error(ex.ToString());
            }

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 加载机构数
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRoleTree()
        {
            var result =new ResultJson();
            try
            {
               var data= roleService.GetRoleTreeList();
                result.Data = data;
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                
                throw;
            }

            return Json(result,JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改用户角色相关
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public JsonResult SaveUserRefRole(int UserId, List<int> RoleId)
        {
            var result = new ResultJson();
            try
            {
                roleService.SaveUserRefRole(UserId,RoleId);
                result.IsSuccess = true;
            }
            catch (Exception ex)
            {

            }
            return Json(result);
        }
        public JsonResult GetMenuByRoleId(int roleId,int flag)
        {
            var result = new ResultJson();
            try
            {
                var data = roleService.GetMenuListByRoleId(roleId,flag);
                result.IsSuccess = true;
                result.Data = data;
            }
            catch (Exception)
            {
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
       
    }
}
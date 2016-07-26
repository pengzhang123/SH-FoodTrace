using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.Common.Log;
using Microsoft.Owin.Security.Facebook;

namespace FoodTrace.WebSite.Controllers
{
    public class UserBaseController : BaseController
    {

        IUserBaseService userBaseService;
        IUserRoleService userRoleIndexService;
        IRoleService roleService;
        IUserDetailService userDetailService;
        ICompanyService companyService;
        IDeptService deptService;
        public UserBaseController(IUserRoleService iService,IRoleService rService,IUserDetailService aService, IUserBaseService uService, ICompanyService cService, IDeptService dService)
        {
            userDetailService = aService;
            userBaseService = uService;
            companyService = cService;
            deptService = dService;
            roleService = rService;
            userRoleIndexService = iService;
        }
        // GET: UserBase
        public ActionResult Index()
        {
            UserManagement.CurrentCompany = new Model.CompanyModel() { CompanyID = 1 };
            var userlist = userBaseService.GetPagerUserBase("", 1, 10);
            var companylist = companyService.GetPagerCompany(string.Empty, 1, 100).Select(_=>new { UserBase_CompanyName=_.CompanyName, UserBase_CompanyID=_.CompanyID });
            var rolelist = roleService.GetPagerRole("", 1, 100);

            ViewBag.RoleList = rolelist;
            //List<SelectListItem> itemList = new List<SelectListItem>();
            //companylist.ForEach(m => {
            //    itemList.Add(new SelectListItem() { Text = m.CompanyName, Value = m.CompanyID.ToString() });
            //});
            //ViewBag.CompanyList = new SelectList(companylist, "UserBase_CompanyName", "UserBase_CompanyID"); ;
            return View();
        }

        public ActionResult Create()
        {
            UserManagement.CurrentCompany = new Model.CompanyModel() { CompanyID = 1 };
            var companylist = companyService.GetPagerCompany(string.Empty, 1, 100).Select(_ => new { CompanyName = _.CompanyName, CompanyID = _.CompanyID });
            //var deptlist = deptService.GetPagerDept(string.Empty, 1, 100).Select(_ => new { DeptName = _.DeptName, DeptID = _.DeptID });
            //var rolelist = roleService.GetPagerRole("", 1, 100);
           
            //ViewBag.RoleList = rolelist;
           // ViewBag.DeptList = new SelectList(deptlist, "DeptID","DeptName");
            ViewBag.CompanyList = new SelectList(companylist, "CompanyID", "CompanyName");
            return View();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create(UserDetailModel model)
        {
            bool isSuccess = false;
            try
            {
                userDetailService.InsertSingleUserBase(model);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return Json(isSuccess);
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var user = userBaseService.GetUserBaseWithDetailById(id);
            var companylist = companyService.GetPagerCompany(string.Empty, 1, 100).Select(_ => new { CompanyName = _.CompanyName, CompanyID = _.CompanyID });
            var deptlist = deptService.GetPagerDept(string.Empty, 1, 100).Select(_ => new { DeptName = _.DeptName, DeptID = _.DeptID });
            //var rolelist = roleService.GetPagerRole("", 1, 100);

            //var userRefRole = userRoleIndexService.GetUserRefRoleByUid(id);
           // ViewBag.UserRefRole = userRefRole;
           // ViewBag.RoleList = rolelist;
            ViewBag.DeptList = new SelectList(deptlist, "DeptID","DeptName",user.DeptID);
            ViewBag.CompanyList = new SelectList(companylist, "CompanyID", "CompanyName",user.CompanyID);
            ViewData.Model = user;
            return View();
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveUserData(UserBaseDto model)
        {
            var result = new ResultJson();
            try
            {
               
                var msg = new MessageModel();
                if (model.UserId == 0)
                {
                    msg = userBaseService.InsertUserBase(model);
                }
                else
                {
                   msg = userBaseService.UpdateUserBase(model);
                }
                if (msg.Status == MessageStatus.Success)
                {
                    result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }

            return Json(result);
        }
        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult UpdateUser(UserDetailModel model)
        {
            bool isSuccess = false;
            try
            {
                userDetailService.InsertSingleUserBase(model);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return Json(isSuccess);
        }
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetUserList(int page, int rows)
        {
            var userlist = userBaseService.GetUserBasePaging("", page, rows);
            return Json(userlist);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Delete(int id)
        {
            var result = new ResultJson();
            try
            {
                var msg = userBaseService.DeleteSingleUserBase(id);
                if (msg.Status == MessageStatus.Success)
                {
                    result.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
             Logger.Error(ex.ToString());
            }
            return Json(result);
        }
        public ActionResult ListInfo()
        {
            UserManagement.CurrentCompany = new Model.CompanyModel() { CompanyID = 1 };
            var companylist = companyService.GetPagerCompany(string.Empty, 1, 100).Select(_ => new { CompanyName = _.CompanyName, CompanyID = _.CompanyID });
            var deptlist = deptService.GetPagerDept(string.Empty, 1, 100).Select(_ => new { DeptName = _.DeptName, DeptID = _.DeptID });
            return Json(new  { companys= companylist, depts= deptlist },  JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(UserDetailModel model, List<int> chkMenu)
        {
            try
            {
                // TODO: Add insert logic here

                //var result = userBaseService.InsertSingleUserBase(model.UserBase);
                //model.UserID = model.UserBase.UserID;
                //var result2 = userDetailService.InsertSingleUserBase(model);
                //var result3 = userRoleIndexService.InsertSingleEntity();
               // var result = userBaseService.InsertSingleEntity(model.UserBase, model, chkMenu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
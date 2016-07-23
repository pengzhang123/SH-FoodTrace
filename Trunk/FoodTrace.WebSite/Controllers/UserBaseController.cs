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
            
            //List<SelectListItem> itemList = new List<SelectListItem>();
            //companylist.ForEach(m => {
            //    itemList.Add(new SelectListItem() { Text = m.CompanyName, Value = m.CompanyID.ToString() });
            //});
            //ViewBag.CompanyList = new SelectList(companylist, "UserBase_CompanyName", "UserBase_CompanyID"); ;
            return View(userlist);
        }

        public ActionResult Create()
        {
            UserManagement.CurrentCompany = new Model.CompanyModel() { CompanyID = 1 };
            var companylist = companyService.GetPagerCompany(string.Empty, 1, 100).Select(_ => new { CompanyName = _.CompanyName, CompanyID = _.CompanyID });
            var deptlist = deptService.GetPagerDept(string.Empty, 1, 100).Select(_ => new { DeptName = _.DeptName, DeptID = _.DeptID });
            var rolelist = roleService.GetPagerRole("", 1, 100);
            ViewBag.RoleList = rolelist;
            ViewBag.DeptList = deptlist;
            ViewBag.CompanyList = companylist;
            return View();
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
                var result = userBaseService.InsertSingleEntity(model.UserBase, model, chkMenu);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
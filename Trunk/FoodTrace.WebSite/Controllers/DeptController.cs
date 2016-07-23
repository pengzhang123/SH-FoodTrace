using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class DeptController : BaseController
    {
        IDeptService deptService;
        ICompanyService companyService;
        public DeptController(IDeptService dService, ICompanyService cService)
        {
            deptService = dService;
            companyService = cService;
        }

        // GET: Dept
        public ActionResult Index()
        {
            //Common.Libraries.UserManagement.CurrentCompany = new CompanyModel() { CompanyID = 1 };
            var lstDept = deptService.GetPagerDept(string.Empty, 1, 100);
            lstDept.ForEach(m => m.UpperDept = deptService.GetDeptById(m.UpperDeptID.HasValue ? m.UpperDeptID.Value : 0));
            return View(lstDept);
        }

        public ActionResult GetList(int page, int rows)
        {
            var lstDept = deptService.GetPagerDept(string.Empty, page, rows).Select(m => new
            {
                DeptID=m.DeptID,
                CompanyName = m.Company.CompanyName,
                DeptName = m.DeptName,
                Address = m.UpperDept.DeptName,
                DeptRemark = m.DeptRemark,
                SortID = m.SortID
            });
            return Json(lstDept, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            Common.Libraries.UserManagement.CurrentCompany = new CompanyModel() { CompanyID = 1 };
            var lstCompany = companyService.GetPagerCompany(string.Empty, 1, 100);
            List<SelectListItem> companyList = new List<SelectListItem>();
            foreach (var item in lstCompany)
            {
                companyList.Add(new SelectListItem() { Text = item.CompanyName, Value = item.CompanyID.ToString() });
            }
            ViewBag.Company = companyList;

            List<SelectListItem> deptList = new List<SelectListItem>();
            ViewBag.Dept = deptList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(DeptModel deptModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (deptModel.UpperDeptID.HasValue && deptModel.UpperDeptID.Value == 0)
                    deptModel.UpperDeptID = null;
                var result = deptService.InsertSingleDept(deptModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit()
        {
            return View();
        }


        public JsonResult GetDeptByCompany(int? companyId)
        {
            List<SelectListItem> deptList = new List<SelectListItem>();
            var lstDept = deptService.GetPagerDept(string.Empty, 1, 100, companyId);
            foreach (var item in lstDept)
            {
                deptList.Add(new SelectListItem() { Text = item.DeptName, Value = item.DeptID.ToString() });
            }
            return Json(deptList);
        }
    }
}
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.Common.Log;

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
            //var lstDept = deptService.GetPagerDept(string.Empty, 1, 100);
            //lstDept.ForEach(m => m.UpperDept = deptService.GetDeptById(m.UpperDeptID.HasValue ? m.UpperDeptID.Value : 0));
            return View();
        }

        public JsonResult GetList(int page, int rows)
        {
            int count = deptService.GetDeptCount();
            var lstDept = deptService.GetPagerDept(string.Empty, page, rows).Select(m => new
            {
                DeptID=m.DeptID,
                CompanyName = m.Company == null ? string.Empty: m.Company.CompanyName,
                DeptName = m.DeptName,
                Address = m.UpperDept==null?string.Empty:m.UpperDept.DeptName,
                DeptRemark = m.DeptRemark,
                SortID = m.SortID
            }).ToList();
            return Json(new { total = count, rows = lstDept }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            //Common.Libraries.UserManagement.CurrentCompany = new CompanyModel() { CompanyID = 1 };
            var lstCompany = companyService.GetPagerCompany(string.Empty, 1, 100);
            List<SelectListItem> companyList = new List<SelectListItem>();
            foreach (var item in lstCompany)
            {
                companyList.Add(new SelectListItem() { Text = item.CompanyName, Value = item.CompanyID.ToString() });
            }
            ViewBag.Company = companyList;

            //List<SelectListItem> deptList = new List<SelectListItem>();
            //ViewBag.Dept = deptList;
            return View();
        }

        [HttpPost]
        public JsonResult Create(DeptModel deptModel)
        {
            var result = false;
            try
            {
                // TODO: Add insert logic here
                if (deptModel.UpperDeptID.HasValue && deptModel.UpperDeptID.Value == 0)
                    deptModel.UpperDeptID = null;
                var msg = deptService.InsertSingleDept(deptModel);
               // return RedirectToAction("Index");
                if (msg.Status == MessageStatus.Success)
                {
                    result = true;
                }
            }
            catch
            {
               
            }

            return Json(result);
        }

        /// <summary>
        /// 编辑页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var model=new DeptModel();

            model = deptService.GetDeptById(id);
            int comId = Convert.ToInt32(model.CompanyID);
            var lstCompany = companyService.GetPagerCompany(string.Empty, 1, 100);
            var lstDept = deptService.GetPagerDept(string.Empty, 1, 100, comId);

            ViewBag.CompanyList = new SelectList(lstCompany, "CompanyID", "CompanyName", comId);
            ViewBag.DeptsList = new SelectList(lstDept, "DeptID", "DeptName", model.DeptID);
            ViewData.Model = model;
            return View();
        }

        /// <summary>
        /// 提交修改数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult EditDept(DeptModel model)
        {
            bool isSuccess = false;
            try
            {
                deptService.UpdateSingleDept(model);
                isSuccess = true;
            }
            catch (Exception ex)
            {
              Logger.Error(ex);
            }
            return Json(isSuccess);
        }

        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Delete(int id)
        {
            bool isSuccess = false;
            try
            {
                deptService.DeleteSingleDept(id);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
          
            return Json(isSuccess);

        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteDept(string ids)
        {
            bool isSuccess = false;
            try
            {
                deptService.DeleteDepts(ids);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            return Json(isSuccess);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public JsonResult GetDeptByCompany(int? companyId)
        {
            List<SelectListItem> deptList = new List<SelectListItem>();
            var lstDept = deptService.GetPagerDept(string.Empty, 1, 100, companyId);
            foreach (var item in lstDept)
            {
                deptList.Add(new SelectListItem() { Text = item.DeptName, Value = item.DeptID.ToString() });
            }
            return Json(deptList,JsonRequestBehavior.AllowGet);
        }
    }
}
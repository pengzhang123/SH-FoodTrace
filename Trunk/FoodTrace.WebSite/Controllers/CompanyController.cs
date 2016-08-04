using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class CompanyController : BaseController
    {
        ICompanyService companyService;
        IAreaPlatService areaPlatService;
        public CompanyController(ICompanyService cService, IAreaPlatService apService)
        {
            companyService = cService;
            areaPlatService = apService;
        }
        // GET: Company
        public ActionResult Index()
        {
          //  UserManagement.CurrentCompany = new Model.CompanyModel() { CompanyID = 1 };
            //var lstCompany = companyService.GetPagerCompany("", 1, 10);
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            var companyList = companyService.GetPagerCompany(string.Empty, page, rows).Select(m => new
            {
                CompanyID = m.CompanyID,
                CompanyName = m.CompanyName,
                AreaCode = m.AreaCode,
                Address = m.Address,
                Leader = m.Leader,
                Logo = m.Logo,
                OrgID = m.OrgID,
                QsCode = m.QsCode,
                Location = m.Location,
                Code = m.Code,
                ZipCode = m.ZipCode,
                TaxCard = m.TaxCard,
                Fax = m.Fax,
                Mobile = m.Mobile,
                Email = m.Email,
                Info = m.Info,
                Demand = m.Demand,
                Remark = m.Remark
            });
            return Json(companyList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var lstAreaPlat = areaPlatService.GetPagerAreaPlat(string.Empty, 1, 1000);
            List<SelectListItem> areaPlatList = new List<SelectListItem>();
            foreach (var item in lstAreaPlat)
            {
                areaPlatList.Add(new SelectListItem() { Text = item.AreaName, Value = item.AreaCode });
            }
            ViewBag.AreaPlat = areaPlatList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyModel companyModel)
        {
            companyModel.ModifyTime = DateTime.Now;
            var result= companyService.InsertSingleCompany(companyModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var company = companyService.GetCompanyById(id);
            var lstAreaPlat = areaPlatService.GetPagerAreaPlat(string.Empty, 1, 1000);
            List<SelectListItem> areaPlatList = new List<SelectListItem>();
            foreach (var item in lstAreaPlat)
            {
                areaPlatList.Add(new SelectListItem() { Text = item.AreaName, Value = item.AreaCode, Selected = company.AreaCode == item.AreaCode });
            }
            ViewBag.AreaPlat = areaPlatList;
            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(CompanyModel companyModel)
        {
            var result = companyService.UpdateSingleCompany(companyModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = companyService.DeleteSingleCompany(id);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteCompany(string ids)
        {
            var result = companyService.DeleteCompanyByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}
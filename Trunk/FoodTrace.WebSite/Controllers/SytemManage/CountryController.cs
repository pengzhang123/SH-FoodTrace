using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using System.Web.Mvc;
using FoodTrace.Model;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.WebSite.Controllers
{
    public class CountryController : BaseController
    {
        ICityService cityService;
        ICountryService countryService;
        IProvinceService provinceService;
        public CountryController(ICityService cityService, ICountryService countryService, IProvinceService provinceService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
            this.provinceService = provinceService;
        }

        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(int page, int rows)
        {
            string countryName = RequestHelper.RequestPost("countryName", string.Empty);
            var list = countryService.GetCountryListPaging(null, countryName, page, rows);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var provinceList = provinceService.GetPagerProvince(null, string.Empty, 1, 100);
            List<SelectListItem> itemList = new List<SelectListItem>();
            provinceList.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.ProvinceName, Value = m.ProvinceID.ToString() });
            });
            ViewBag.ProvinceList = itemList;
          
            return PartialView(new CountryModel());
        }

        [HttpPost]
        public ActionResult Create(CountryModel model)
        {
            var result = countryService.InsertSingleCountry(model);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var model = countryService.GetCountryById(id);
            var provinceList = provinceService.GetPagerProvince(null, string.Empty, 1, 100);
            List<SelectListItem> itemList = new List<SelectListItem>();
            provinceList.ForEach(m =>
            {
                itemList.Add(new SelectListItem()
                {
                    Text = m.ProvinceName, Value = m.ProvinceID.ToString(),
                    Selected = m.ProvinceID==model.ProvinceId ?true:false
                });
            });
            ViewBag.ProvinceList = itemList;

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(CountryModel model)
        {
            var result = countryService.UpdateSingleCountry(model);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = countryService.DeleteSingleCountry(id);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public JsonResult DeleteByIds(string ids)
        {
            var result = countryService.DeleteByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}
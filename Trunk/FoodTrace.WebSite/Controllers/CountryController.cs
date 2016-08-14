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

        public CountryController(ICityService cityService, ICountryService countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
        }

        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            var count = countryService.GetCountryCount();
            string countryName = RequestHelper.RequestPost("countryName", string.Empty);
            var list = countryService.GetPagerCountry(null, countryName, page, rows).Select(_ => new
            {
                CityID = _.CityID,
                CityName = _.City.CityName,
                CountryCode = _.CountryCode,
                CountryName = _.CountryName,
                CountryID = _.CountryID
            });
            return Json(new{total=count,rows=list}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var areaList = cityService.GetPagerCity(null, string.Empty, 1, 100);
            List<SelectListItem> itemList = new List<SelectListItem>();
            areaList.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.CityName, Value = m.CityID.ToString() });
            });
            ViewBag.CityList = itemList;
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
            var areaList = cityService.GetPagerCity(null, string.Empty, 1, 100);
            List<SelectListItem> itemList = new List<SelectListItem>();
            areaList.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.CityName, Value = m.CityID.ToString() });
            });
            ViewBag.CityList = itemList;
            var model = countryService.GetCountryById(id);
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
using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using System.Web.Mvc;
using FoodTrace.Model;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.WebSite.Controllers
{
    public class ProvinceController : BaseController
    {
        IProvinceService provinceService;
        IAreaService areaService;

        public ProvinceController(IProvinceService provinceService, IAreaService areaService)
        {
            this.provinceService = provinceService;
            this.areaService = areaService;
        }

        // GET: Province
        public ActionResult Index()
        {
            var provinceList = provinceService.GetPagerProvince(null, string.Empty, 1, 10);
            return View(provinceList);
        }

        public ActionResult GetList(int page, int rows)
        {
           // var count = provinceService.GetProvinceCount();
            string provinceName = RequestHelper.RequestPost("provinceName", string.Empty);
            var provinceList = provinceService.GetProviceListPaging(null, provinceName, page, rows);
            return Json(provinceList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var areaList = areaService.GetPagerArea(string.Empty, 1, 100);
            List<SelectListItem> itemList = new List<SelectListItem>();
            areaList.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.AreaName, Value = m.AreaID.ToString() });
            });
            ViewBag.AreaList = itemList;
            return PartialView(new ProvinceModel());
        }

        [HttpPost]
        public ActionResult Create(ProvinceModel provinceModel)
        {
            var result = provinceService.InsertSingleProvince(provinceModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var areaList = areaService.GetPagerArea(string.Empty, 1, 100);
            List<SelectListItem> itemList = new List<SelectListItem>();
            areaList.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.AreaName, Value = m.AreaID.ToString() });
            });
            ViewBag.AreaList = itemList;
            var province = provinceService.GetProvinceById(id);
            return PartialView(province);
        }

        [HttpPost]
        public ActionResult Edit(ProvinceModel provinceModel)
        {
            var result = provinceService.UpdateSingleProvince(provinceModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = provinceService.DeleteSingleProvince(id);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteByIds(string ids)
        {
            var result = provinceService.DeleteByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}
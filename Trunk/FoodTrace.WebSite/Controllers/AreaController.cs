using FoodTrace.IService;
using System.Web.Mvc;
using FoodTrace.Model;
using System.Linq;

namespace FoodTrace.WebSite.Controllers
{
    public class AreaController : BaseController
    {
        IAreaService areaService;
        public AreaController(IAreaService areaService)
        {
            this.areaService = areaService;
        }

        // GET: Province
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            var provinceList = areaService.GetPagerArea(string.Empty, page, rows).Select(_ => new
            {
                AreaID = _.AreaID,
                AreaName = _.AreaName
            });
            return Json(provinceList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return PartialView(new AreaModel());
        }

        [HttpPost]
        public ActionResult Create(AreaModel model)
        {
            var result = areaService.InsertSingleArea(model);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var model = areaService.GetAreaById(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Edit(AreaModel model)
        {
            var result = areaService.UpdateSingleArea(model);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = areaService.DeleteSingleArea(id);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}

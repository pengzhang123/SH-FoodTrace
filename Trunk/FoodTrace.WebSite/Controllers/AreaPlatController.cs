using Antlr.Runtime.Tree;
using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class AreaPlatController : BaseController
    {
        IAreaPlatService areaPlatService;
        public AreaPlatController(IAreaPlatService areaPlatService)
        {
            this.areaPlatService = areaPlatService;
        }
        // GET: AreaPlat
        public ActionResult Index()
        {
            //var areaPlatList = areaPlatService.GetPagerAreaPlat(string.Empty, 1, 100);
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            int count = areaPlatService.GetAreaPlatCount();

            var areaPlatList = areaPlatService.GetPagerAreaPlat(string.Empty, page, rows).Select(m => new
            {
                AreaID=m.AreaID,
                AreaCode = m.AreaCode,
                AreaName = m.AreaName,
                Remark = m.Remark
            });
            return Json(new{total=count,rows=areaPlatList}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Area/Create
        [HttpPost]
        public ActionResult Create(AreaPlatModel areaPlatModel)
        {
            areaPlatModel.ModifyTime = DateTime.Now;
            // TODO: Add insert logic here
            var result = areaPlatService.InsertSingleAreaPlat(areaPlatModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var areaPlat = areaPlatService.GetAreaPlatById(id);
            return View(areaPlat);
        }

        [HttpPost]
        public ActionResult Edit(AreaPlatModel areaPlatModel)
        {
            var result = areaPlatService.UpdateSingleAreaPlat(areaPlatModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = areaPlatService.DeleteSingleAreaPlat(id);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteAreaPlat(string ids)
        {
            var result = areaPlatService.DeleteAreaPlatByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class ProductEpcController : BaseController
    {
        IProductSpecService productSpecService;

        public ProductEpcController(IProductSpecService pSpecService)
        {
            this.productSpecService = pSpecService;
            //this.provinceService = provinceService;
        }
        // GET: ProductEpc
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(int page, int rows)
        {
            var count = productSpecService.GetProductSpecCount();
            var productSpecList = productSpecService.GetPagerProductSpec(string.Empty, page, rows).Select(m => new
            {
                SPCID = m.SPCID,
                ClassID = m.ClassID,
                ClassName = m.ClassName,
                SpecCode = m.SpecCode,
                SpecName = m.SpecName,
                Remark = m.Remark,
                IsLocked = m.IsLocked,
                IsShow = m.IsShow,
            });
            return Json(new { total =count ,rows=productSpecList}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return PartialView(new ProductSpecModel());
        }

        [HttpPost]
        public ActionResult Create(ProductSpecModel productSpecModel)
        {
            var result = productSpecService.InsertSingleProductSpec(productSpecModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var productSpec = productSpecService.GetProductSpecById(id);
            return PartialView(productSpec);
        }

        [HttpPost]
        public ActionResult Edit(ProductSpecModel productSpecModel)
        {
            var result = productSpecService.UpdateSingleProductSpec(productSpecModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = productSpecService.DeleteSingleProductSpec(id);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }


        public JsonResult DeleteByIds(string ids)
        {
            var result = productSpecService.DeleteByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}
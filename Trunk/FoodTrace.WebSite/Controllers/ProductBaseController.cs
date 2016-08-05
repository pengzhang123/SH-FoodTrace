using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class ProductBaseController : BaseController
    {
        private IProductBaseService productBaseService;
        private IProductTypeService productTypeService;
        private IProductSpecService productSpecService;
        public ProductBaseController(IProductBaseService pBaseService, IProductTypeService pTypeService, IProductSpecService pSpecService)
        {
            productBaseService = pBaseService;
            productTypeService = pTypeService;
            productSpecService = pSpecService;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            var productSpecList = productBaseService.GetPagerProductBase(string.Empty, page, rows).Select(m => new
            {
                ProductID = m.ProductID,
                ProductName = m.ProductName,
                ClassID = m.ClassID,
                ClassName = m.ClassName,
                ProductCode = m.ProductCode,
                ProductSpcID = m.ProductSpcID,
                SpecName = m.ProductSpec.SpecName,
                ProductTypeID = m.ProductTypeID,
                ProductTypeEN = m.ProductType.ProductTypeEN,
                Weight = m.Weight,
                PinYinCode = m.PinYinCode,
                Price = m.Price,
                Remark = m.Remark,
                IsLocked = m.IsLocked,
                IsShow = m.IsShow,
            });
            return Json(productSpecList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            var productSpcList = productSpecService.GetPagerProductSpec(string.Empty, 1, 100);
            List<SelectListItem> itemList = new List<SelectListItem>();
            productSpcList.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.SpecName, Value = m.SPCID.ToString() });
            });
            ViewBag.ProductSpcList = itemList;

            var productTypeList = productTypeService.GetPagerProductType(string.Empty, 1, 100);
            itemList = new List<SelectListItem>();
            productTypeList.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.ProductTypeEN, Value = m.ProductTypeID.ToString() });
            });
            ViewBag.ProductTypeList = itemList;

            return PartialView(new ProductBaseModel());
        }

        [HttpPost]
        public ActionResult Create(ProductBaseModel productBaseModel)
        {
            var result = productBaseService.InsertSingleProductBase(productBaseModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var productSpcList = productSpecService.GetPagerProductSpec(string.Empty, 1, 100);
            List<SelectListItem> itemList = new List<SelectListItem>();
            productSpcList.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.SpecName, Value = m.SPCID.ToString() });
            });
            ViewBag.ProductSpcList = itemList;

            var productTypeList = productTypeService.GetPagerProductType(string.Empty, 1, 100);
            itemList = new List<SelectListItem>();
            productTypeList.ForEach(m =>
            {
                itemList.Add(new SelectListItem() { Text = m.ProductTypeEN, Value = m.ProductTypeID.ToString() });
            });
            ViewBag.ProductTypeList = itemList;

            var productType = productBaseService.GetProductBaseById(id);
            return PartialView(productType);
        }

        [HttpPost]
        public ActionResult Edit(ProductBaseModel productBaseModel)
        {
            var result = productBaseService.UpdateSingleProductBase(productBaseModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = productBaseService.DeleteSingleProductBase(id);
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
            var result = productBaseService.DeleteByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}
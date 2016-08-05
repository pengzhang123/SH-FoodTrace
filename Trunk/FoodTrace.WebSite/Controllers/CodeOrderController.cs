using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class CodeOrderController : BaseController
    {
        private ICodeOrderService codeOrderService;
        public CodeOrderController(ICodeOrderService coService)
        {
            codeOrderService = coService;
        }
        // GET: CodeMax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            var count = codeOrderService.GetCodeOrderCount();
            var productSpecList = codeOrderService.GetPagerCodeOrder(string.Empty, page, rows).Select(m => new
            {
                OrderID = m.OrderID,
                ObjectCode = m.ObjectCode,
                ObjectName = m.ObjectName,
                Prefix = m.Prefix,
                DateFormat = m.DateFormat,
                SeqType = m.SeqType,
                SeqLength = m.SeqLength,
                MaxLength = m.MaxLength,
                SortID = m.SortID,
                Remark = m.Remark,
                IsLocked = m.IsLocked,
                IsShow = m.IsShow
            });
            return Json(new{total=count,rows=productSpecList}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return PartialView(new CodeOrderModel());
        }

        [HttpPost]
        public ActionResult Create(CodeOrderModel codeOrderModel)
        {
            var result = codeOrderService.InsertSingleCodeOrder(codeOrderModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var codeOrder = codeOrderService.GetCodeOrderById(id);
            return PartialView(codeOrder);
        }

        [HttpPost]
        public ActionResult Edit(CodeOrderModel codeOrderModel)
        {
            var result = codeOrderService.UpdateSingleCodeOrder(codeOrderModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = codeOrderService.DeleteSingleCodeOrder(id);
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
            var result = codeOrderService.DeleteByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}
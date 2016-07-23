using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class CodeMaxController : BaseController
    {
        private ICodeMaxService codeMaxService;
        public CodeMaxController(ICodeMaxService cmService)
        {
            codeMaxService = cmService;
        }
        // GET: CodeMax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            var productSpecList = codeMaxService.GetPagerCodeMax(string.Empty, page, rows).Select(m => new
            {
                CodeMaxID = m.CodeMaxID,
                ObjectCode = m.ObjectCode,
                ObjectName = m.ObjectName,
                ObjectValue = m.ObjectValue,
                SortID = m.SortID,
                Remark = m.Remark,
                IsLocked = m.IsLocked,
                IsShow = m.IsShow
            });
            return Json(productSpecList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return PartialView(new CodeMaxModel());
        }

        [HttpPost]
        public ActionResult Create(CodeMaxModel codeMaxModel)
        {
            var result = codeMaxService.InsertSingleCodeMax(codeMaxModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var productType = codeMaxService.GetCodeMaxById(id);
            return PartialView(productType);
        }

        [HttpPost]
        public ActionResult Edit(CodeMaxModel codeMaxModel)
        {
            var result = codeMaxService.UpdateSingleCodeMax(codeMaxModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = codeMaxService.DeleteSingleCodeMax(id);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }
    }
}
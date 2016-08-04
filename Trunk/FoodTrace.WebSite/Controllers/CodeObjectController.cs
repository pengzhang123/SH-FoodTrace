using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTrace.WebSite.Controllers
{
    public class CodeObjectController : BaseController
    {
        private ICodeObjectService codeObjectService;
        public CodeObjectController(ICodeObjectService coService)
        {
            codeObjectService = coService;
        }
        // GET: CodeMax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int page, int rows)
        {
            var count = codeObjectService.GetCodeObjectCount();
            var productSpecList = codeObjectService.GetPagerCodeObject(string.Empty, page, rows).Select(m => new
            {
                ObjectID = m.ObjectID,
                ObjectCode = m.ObjectCode,
                ObjectName = m.ObjectName,
                Prefix = m.Prefix,
                MaxLength = m.MaxLength,
                SeqLength = m.SeqLength,
                IsFixedLength = m.IsFixedLength,
                IsAuto = m.IsAuto,
                SortID = m.SortID,
                Remark = m.Remark,
                IsLocked = m.IsLocked,
                IsShow = m.IsShow
            });
            return Json(new{total=count,rows= productSpecList}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return PartialView(new CodeObjectModel());
        }

        [HttpPost]
        public ActionResult Create(CodeObjectModel codeObjectModel)
        {
            var result = codeObjectService.InsertSingleCodeObject(codeObjectModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        public ActionResult Edit(int id)
        {
            var codeObject = codeObjectService.GetCodeObjectById(id);
            return PartialView(codeObject);
        }

        [HttpPost]
        public ActionResult Edit(CodeObjectModel codeObjectModel)
        {
            var result = codeObjectService.UpdateSingleCodeObject(codeObjectModel);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var result = codeObjectService.DeleteSingleCodeObject(id);
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
            var result = codeObjectService.DeleteByIds(ids);
            var flag = result.Status == MessageStatus.Success ? true : false;
            var msg = result.Message;
            return Json(new { flag = flag, msg = msg });
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.IService.SystemBase;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.WebSite.Controllers
{
    public class DicController : BaseController
    {

         private readonly IDicService _dicService;

        public DicController(IDicService dicService)
        {
            _dicService = dicService;
        }
        // GET: Dic
        public ActionResult Index()
        {
            var dicRoot = _dicService.GetDicrootList(1, 100);

            ViewBag.DicRoot = new SelectList(dicRoot.rows, "RootID", "Name");
            return View();
        }

        /// <summary>
        /// 数据列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetDicList(int page, int rows)
        {
            var list = new GridList<DicModel>();
            try
            {
                list = _dicService.GetDicList(page, rows);
            }
            catch (Exception)
            {

                throw;
            }

            return Json(list);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveDic(DicModel model)
        {
            var result = new ResultJson();
            try
            {
                if (model.DicID == 0)
                {
                    _dicService.InsertDicData(model);
                }
                else
                {
                    _dicService.UpdateDicData(model);
                }
                result.IsSuccess = true;
            }
            catch (Exception)
            {

                throw;
            }

            return Json(result);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteByIds(string ids)
        {
            var result = new ResultJson();
            try
            {
                _dicService.DeleteDicByIds(ids);
                result.IsSuccess = true;

            }
            catch (Exception)
            {

                throw;
            }

            return Json(result);
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetDicById(int id)
        {
            var result = new ResultJson();
            try
            {
                _dicService.GetDicModelById(id);
                result.IsSuccess = true;

            }
            catch (Exception)
            {

                throw;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
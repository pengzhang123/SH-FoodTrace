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
    public class DicRootController : BaseController
    {
        private readonly IDicService _dicService;

        public DicRootController(IDicService dicService)
        {
            _dicService = dicService;
        }
        // GET: DicRoot
        public ActionResult Index()
        {
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
            var list = new GridList<DicRootModel>();
            try
            {
                list = _dicService.GetDicrootList(page, rows);
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
        public JsonResult SaveRootDic(DicRootModel model)
        {
            var result = new ResultJson();
            try
            {
                if (model.RootID == 0)
                {
                    _dicService.InsertDicRootData(model);
                }
                else
                {
                    _dicService.UpdateDicRootData(model);
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
                _dicService.DeleteDicRootByIds(ids);
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
        public JsonResult GetDicRootById(int id)
        {
            var result = new ResultJson();
            try
            {
                _dicService.GetDicRootModelById(id);
                result.IsSuccess = true;

            }
            catch (Exception)
            {

                throw;
            }

            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}
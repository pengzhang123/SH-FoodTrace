using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;


namespace FoodTrace.WebSite.Controllers.BreedManage
{
    public class CultivationController : BaseController
    {
        private readonly ICultivationBaseService _cultivationBaseService;

        public CultivationController(ICultivationBaseService cultivationBaseService)
        {
            _cultivationBaseService = cultivationBaseService;
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetList(int page, int rows)
        {
            var data = new GridList<CultivationDto>();
            try
            {
              
            }
            catch (Exception)
            {
                
                throw;
            }

            return JsonEx(data);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveData(CultivationBaseModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.CultivationID == 0)
                {
                    msg = _cultivationBaseService.InsertSingleCultivationBase(model);
                }
                else
                {
                    msg = _cultivationBaseService.UpdateSingleCultivationBase(model);
                }

                if (msg.Status == MessageStatus.Success)
                {
                    result.IsSuccess = true;
                }
            }
            catch (Exception)
            {
                
            }

            return Json(result);
        }

        /// <summary>
        /// 根据id获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetCultivationById(int id)
        {
            var result = new ResultJson();
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }

            return JsonEx(result);
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

            }
            catch (Exception)
            {
                
                throw;
            }

            return Json(result);
        }
	}
}
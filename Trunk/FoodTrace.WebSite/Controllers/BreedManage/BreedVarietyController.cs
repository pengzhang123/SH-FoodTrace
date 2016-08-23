using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.IService.BreedMng;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.BreedMng;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.WebSite.Controllers.BreedManage
{
    public class BreedVarietyController : BaseController
    {
        private readonly IBreedVarietyService _breedVarietyService;

        public BreedVarietyController(IBreedVarietyService breedVarietyService)
        {
            _breedVarietyService = breedVarietyService;
        }
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetList(int page, int rows)
        {
            var data = new GridList<BreedVarietyDto>();
            try
            {
                data = _breedVarietyService.GetVarietyGridList(page, rows);
            }
            catch (Exception)
            {
             
            }

            return Json(data);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveData(BreedVarietyModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.VarietyId == 0)
                {
                    msg = _breedVarietyService.InsertVarietyModel(model);
                }
                else
                {
                    msg = _breedVarietyService.UpdateVarietyModel(model);
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
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetVarietyDtoById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _breedVarietyService.GetVarietyDtoById(id);
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                
            }
            return Json(result);
        }

        public JsonResult DeleteByIds(string ids)
        {
            var result = new ResultJson();
            try
            {
                var msg = _breedVarietyService.DeleteByIds(ids);
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
	}
}
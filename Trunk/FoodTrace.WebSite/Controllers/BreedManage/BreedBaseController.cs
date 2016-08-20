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
    public class BreedBaseController : BaseController
    {

        private readonly ILandBaseService _landBaseService;
        private readonly IBreedBaseService _breedBaseService;

        public BreedBaseController(IBreedBaseService breedBaseService,ILandBaseService landBaseService)
        {
            _breedBaseService = breedBaseService;
            _landBaseService = landBaseService;
        }
        public ActionResult Index()
        {
            var land = _landBaseService.GetLandBaseListByType(2);
            ViewBag.LandBase = new SelectList(land, "LandId", "LandName");
            return View();
        }

        /// <summary>
        /// 数据列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetList(int page, int rows)
        {
            var data = new GridList<BreedBaseDto>();
            try
            {
                data = _breedBaseService.GetBreedBaseListPaging(page, rows);

            }
            catch (Exception)
            {
             
            }

            return JsonEx(data);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveBreedBaseData(BreedBaseModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if(model.BreedID == 0)
                {
                    msg = _breedBaseService.InsertSingleBreedBase(model);
                }
                else
                {
                    msg = _breedBaseService.UpdateSingleBreedBase(model);
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
        /// 根据Id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetBreedBaseById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _breedBaseService.GetBreedBaseDtoById(id);
                result.IsSuccess = true;
            }
            catch (Exception)
            {
                
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
                result.Data = _breedBaseService.DeleteByIds(ids);
                result.IsSuccess = true;
            }
            catch (Exception)
            {

            }

            return Json(result);
        }
	}
}
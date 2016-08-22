using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.IService;
using FoodTrace.IService.BreedMng;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.WebSite.Controllers.BreedManage
{
    public class BreedAreaController : BaseController
    {
        private readonly IBreedBaseService _breedBaseService;
        private readonly IBreedAreaService _areaService;
        private readonly IBreedVarietyService _breedVarietyService;
        public BreedAreaController(IBreedAreaService areaService,IBreedVarietyService breedVarietyService
            ,IBreedBaseService breedBaseService)
        {
            _breedVarietyService = breedVarietyService;
            _areaService = areaService;
            _breedBaseService = breedBaseService;
        }
        public ActionResult Index()
        {
            var breedbase = _breedBaseService.GetBreedBaseListPaging(1, 1000);
            var varietyList = _breedVarietyService.GetVarietyList();

            ViewBag.BreedBase = new SelectList(breedbase.rows, "BreedID", "BreedName");
            ViewBag.VarietyList = new SelectList(varietyList, "VarietyId", "VarietyName");
            return View();
        }

        /// <summary>
        ///获取数据列表 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetList(int page, int rows)
        {
            var data = new GridList<BreedAreaDto>();
            try
            {
                data = _areaService.GetAreaGridList(page, rows);
            }
            catch (Exception)
            {
                
            }

            return Json(data);
        }

        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetBreedAreaById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _areaService.GetAreaDtoById(id);
                result.IsSuccess = true;
            }
            catch (Exception)
            {
              
            }

            return Json(result);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveBreedAreaData(BreedAreaModel model)
        {
            var result = new ResultJson();
                var msg = new MessageModel();
                try
                {
                    if (model.AreaID == 0)
                    {
                        msg = _areaService.InsertSingleBreedArea(model);
                    }
                    else
                    {
                        msg = _areaService.UpdateSingleBreedArea(model);
                    }

                    if(msg.Status==MessageStatus.Success)
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
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteByIds(string ids)
        {
            var result = new ResultJson();
            try
            {
                var msg = _areaService.DeleteByIds(ids);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.WebSite.Controllers.PlantManage
{
    public class PlantDrugController : BaseController
    {
        private readonly IPlansDrugService _plansDrugService;
        private readonly IPlansBatchService _plansBatchService;

        public PlantDrugController(IPlansDrugService plansDrugService,IPlansBatchService plansBatchService)
        {
            _plansDrugService = plansDrugService;
            _plansBatchService = plansBatchService;
        }
        public ActionResult Index()
        {
            var batch = _plansBatchService.GetPlatPlanList(1, 1000);
            ViewBag.BatchList = new SelectList(batch.rows, "BatchID", "BatchNO");
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
            var data = new GridList<PlantDrugDto>();
            try
            {
                data = _plansDrugService.GetPlanDrugList(page, rows);
            }
            catch (Exception)
            {
      
            }

            return JsonEx(data, "yyyy-MM-dd");
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SavePlantDrugData(PlansDrugModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.DrugID == 0)
                {
                   msg= _plansDrugService.InsertSinglePlansDrug(model);
                }
                else
                {
                   msg= _plansDrugService.UpdateSinglePlansDrug(model);
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
        public JsonResult GetPlantDrugById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _plansDrugService.GetPlantDrugDtoById(id);
                result.IsSuccess = true;
            }
            catch (Exception)
            {
             
            }

            return JsonEx(result, "yyyy-MM-dd");
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
                var msg = _plansDrugService.DeleteByIds(ids);
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
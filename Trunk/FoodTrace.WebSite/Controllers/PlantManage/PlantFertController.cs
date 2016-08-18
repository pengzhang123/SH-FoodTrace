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
    public class PlantFertController : BaseController
    {

        private readonly IPlansFertService _plansFertService;
        private readonly IPlansBatchService _plansBatchService;
        public PlantFertController(IPlansFertService plansFertService,IPlansBatchService plansBatchService)
        {
            _plansFertService = plansFertService;
            _plansBatchService = plansBatchService;
        }
        public ActionResult Index()
        {
            var batch = _plansBatchService.GetPlatPlanList(1, 1000);
            ViewBag.BatchList = new SelectList(batch.rows, "BatchID", "BatchNO");
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
            var data = new GridList<PlansFertDto>();
            try
            {
                data = _plansFertService.GetPlansFertPagingList(string.Empty, page, rows);
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
        public JsonResult SavePlantFert(PlansFertModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.FertID == 0)
                {
                    msg = _plansFertService.InsertSinglePlansFert(model);
                }
                else
                {
                    msg = _plansFertService.UpdateSinglePlansFert(model);
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
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetFertById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _plansFertService.GetFerDtoById(id);
                result.IsSuccess = true;
            }
            catch (Exception)
            {
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
               var msg= _plansFertService.DeleteByIds(ids);
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
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
    public class PlantPlanController : BaseController
    {

        private readonly IPlansBatchService _plansBatchService;
        private readonly ICodeMaxService _codeMaxService;
        private readonly ILandBlockService _landBlockService;
        private readonly ISeedBaseService _seedBaseService;
        public PlantPlanController(ICodeMaxService codeMaxService,IPlansBatchService plansBatchService,
            ILandBlockService landBlockService,ISeedBaseService seedBaseService)
        {
            _codeMaxService = codeMaxService;
            _plansBatchService = plansBatchService;
            _landBlockService = landBlockService;
            _seedBaseService = seedBaseService;
        }
        // GET: /PlantPlan/
        public ActionResult Index()
        {
            var landBlock = _landBlockService.GetLandBlockPaging(string.Empty, 1, 1000);
            var seed = _seedBaseService.GetSeedPagingList(string.Empty, 1, 1000);

            ViewBag.LandBlock = new SelectList(landBlock.rows, "BlockID", "BlockName");
            ViewBag.SeedList = new SelectList(seed.rows, "SeedID", "SeedName");
            return View();
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetList(int page, int rows)
        {
            var list = new GridList<PlatPlanDto>();
            try
            {
                list = _plansBatchService.GetPlatPlanList(page, rows);
            }
            catch (Exception)
            {

            }

            return JsonEx(list);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SavePlanData(PlansBatchModel model)
        {
            var result = new ResultJson();
            try
            {
                CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
                //种植场号
                pro96.BusinessCode = "3";
                //批次号
                pro96.BatchNo =model.BatchNO;
                //生成日期
                pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
                var maxId = _codeMaxService.GetMaxCode("PlansBatch");
                //序号
                pro96.SeqNo = maxId;
                //标签类型
                pro96.EpcType = "3";
                model.BatchCode = pro96.PackEpc();

                var msg = new MessageModel();
                if (model.BatchID == 0)
                {
                    msg = _plansBatchService.InsertSinglePlansBatch(model);
                }
                else
                {
                    msg = _plansBatchService.UpdateSinglePlansBatch(model);
                }

                if (msg.Status == MessageStatus.Success)
                {
                    result.IsSuccess = true;
                }
            }
            catch (Exception)
            {
                
                throw;
            }


            return Json(result);
        }

        /// <summary>
        /// 根据id获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetPlatPlan(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _plansBatchService.GetPlatPlanDtoById(id);
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
                var msg = _plansBatchService.DleteByIds(ids);
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
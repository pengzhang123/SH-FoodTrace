using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.WebSite.Controllers.PlantManage
{
    public class PlantPlanController : BaseController
    {

        private readonly IPlansBatchService _plansBatchService;
        private readonly ICodeMaxService _codeMaxService;

        public PlantPlanController(ICodeMaxService codeMaxService,IPlansBatchService plansBatchService)
        {
            _codeMaxService = codeMaxService;
            _plansBatchService = plansBatchService;
        }
        // GET: /PlantPlan/
        public ActionResult Index()
        {
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
            var list = new GridList<PlansBatchModel>();
            try
            {
                list.rows = _plansBatchService.GetPagerPlansBatch("", page, rows);
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
            CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
            //种植场号
            pro96.BusinessCode = "3";
            //批次号
            pro96.BatchNo = "";
            //生成日期
            pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
            var maxId = _codeMaxService.GetMaxCode("PlansBatch");
            //序号
            pro96.SeqNo = maxId;
            //标签类型
            pro96.EpcType = "3";
            model.BatchCode = pro96.PackEpc();

            return Json(true);
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
                
            }
            catch (Exception)
            {
                
            
            }

            return Json(result);
        }
	}
}
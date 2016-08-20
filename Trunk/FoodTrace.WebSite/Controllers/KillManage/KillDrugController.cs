using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.WebSite.Controllers.KillManage
{
    public class KillDrugController : BaseController
    {
        private readonly IKillDrugService _killDrugService;
        private readonly IKillCullService _killCullService;
        public KillDrugController(IKillDrugService killDrugService,IKillCullService killCullService)
        {
            _killDrugService = killDrugService;
            _killCullService = killCullService;
        }
        public ActionResult Index()
        {
            var killcull = _killCullService.GetKillCullListPaging(1, 1000);
            ViewBag.KillCull = new SelectList(killcull.rows, "KillCullID", "KillEpc");
            return View();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetList(int page, int rows)
        {
            var data = new GridList<KillDrugDto>();
            try
            {
                data = _killDrugService.GetKillDrugListPaging(page, rows);

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
        public JsonResult SaveKillDrugData(KillDrugModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.DrugID == 0)
                {
                    msg = _killDrugService.InsertSingleKillDrug(model);
                }
                else
                {
                    msg = _killDrugService.UpdateSingleKillDrug(model);
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
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteByIds(string ids)
        {
            var result = new ResultJson();
            try
            {
                var msg = _killDrugService.DeleteByIds(ids);
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
        public JsonResult GetKillDrugById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _killDrugService.GetKillDrugDtoById(id);
                result.IsSuccess = true;
            }
            catch (Exception)
            {
             
            }

            return JsonEx(result);
        }
	}
}
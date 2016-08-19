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
    public class KillBatchController : BaseController
    {
        private readonly IKillBatchService _killBatchService;

        public KillBatchController(IKillBatchService killBatchService)
        {
            _killBatchService = killBatchService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetList(int page, int rows)
        {
            var data = new GridList<KillBatchDto>();
            try
            {
                data = _killBatchService.GetKillBatchListPaging(page, rows);
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
        public JsonResult SaveData(KillBatchModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.KillBatchID == 0)
                {
                    msg = _killBatchService.InsertSingleKillBatch(model);
                }
                else
                {
                    msg = _killBatchService.UpdateSingleKillBatch(model);
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
               var msg = _killBatchService.DeleteByIds(ids);
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
        public JsonResult GetKillBatchById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _killBatchService.GetKillBatchDtoById(id);
                result.IsSuccess = true;
            }
            catch (Exception)
            {
               
            }

            return Json(result);
        }
	}
}
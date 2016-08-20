using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;
using Microsoft.AspNet.Identity;

namespace FoodTrace.WebSite.Controllers.KillManage
{
    public class KillController : BaseController
    {
        
        private readonly IKillBatchService _batchService;
        private readonly ICultivationBaseService _cultivationBaseService;
        private readonly ICodeMaxService _codeMaxService;
        private readonly IKillCullService _killCullService;
        public KillController(IKillBatchService batchService,
            ICultivationBaseService cultivationBaseService,ICodeMaxService codeMaxService,
             IKillCullService killCullService)
        {
            _batchService = batchService;
            _cultivationBaseService = cultivationBaseService;
            _killCullService = killCullService;
            _codeMaxService = codeMaxService;
        }
        public ActionResult Index()
        {
            //屠宰批次
            var killBatch = _batchService.GetKillBatchListPaging(1, 1000);
            ViewBag.KillBatch = new SelectList(killBatch.rows, "KillBatchID", "BatchNO");
            //个体
            var cultivation = _cultivationBaseService.GetPagerCultivationBase(string.Empty, 1, 1000);
            ViewBag.Cultivation = new SelectList(cultivation, "CultivationID", "CultivationEPC");
            return View();
        }


        public JsonResult GetList(int page, int rows)
        {
            var data = new GridList<KillCullDto>();
            try
            {
                data = _killCullService.GetKillCullListPaging(page, rows);

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
        public JsonResult SaveKillCullData(KillCullModel model)
        {
            var result = new ResultJson();
            try
            {
                CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
                //种植场号
                pro96.BusinessCode = UserManagement.CurrentUser.CompanyId.ToString();
                //批次号
                pro96.GoodsCode =model.KillBatchID.ToString();
                //生成日期
                pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
                var maxId = _codeMaxService.GetMaxCode("KillCull");
                //序号
                pro96.SeqNo = maxId;
                //标签类型
                pro96.EpcType = "3";
               model.KillEpc = pro96.PackEpc();

                model.CompanyID = UserManagement.CurrentUser.CompanyId;
                var msg = new MessageModel();
                if (model.KillCullID == 0)
                {
                    msg = _killCullService.InsertSingleKillCull(model);
                }
                else
                {
                    msg = _killCullService.UpdateSingleKillCull(model);
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
        /// 获取单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetKillCullById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _killCullService.GetKillCullDtoById(id);
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
                var msg = _killCullService.DeleteByIds(ids);
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
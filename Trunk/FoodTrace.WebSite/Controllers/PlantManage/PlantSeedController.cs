using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.WebSite.Controllers.PlantManage
{
    public class PlantSeedController : BaseController
    {
        private readonly ISeedBaseService _seedBaseService;
        private readonly ICodeMaxService _codeMaxService;
        public PlantSeedController(ISeedBaseService seedBaseService,ICodeMaxService codeMaxService)
        {
            _seedBaseService = seedBaseService;
            _codeMaxService = codeMaxService;
        }

        // GET: /PlatSeed/
        public ActionResult Index()
        {
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
            var data = new GridList<SeedDto>();
            try
            {
                string seedName = RequestHelper.RequestPost("seedName", string.Empty);
                data = _seedBaseService.GetSeedPagingList(seedName, page, rows);
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
        public JsonResult SaveSeedData(SeedBaseModel model)
        {
            var result = new ResultJson();
            try
            {

                CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
                //种植场号
                pro96.BusinessCode = "3";
                //批次号
                pro96.BatchNo = model.BatchNO;
                //生成日期
                pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
                var maxId = _codeMaxService.GetMaxCode("SeedBase");
                //序号
                pro96.SeqNo = maxId;
                //标签类型
                pro96.EpcType = "3";
                model.SeedCode= pro96.PackEpc();


                var msg = new MessageModel();
                if (model.SeedID == 0)
                {
                    msg=_seedBaseService.InsertSingleSeedBase(model);
                }
                else
                {
                    msg=_seedBaseService.UpdateSingleSeedBase(model);
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
        public JsonResult GetSeedById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _seedBaseService.GetSeedDtoById(id);
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
        public JsonResult DeleteSeedByIds(string ids)
        {
            var result = new ResultJson();
            try
            {
                var msg = _seedBaseService.DeleteByIds(ids);
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
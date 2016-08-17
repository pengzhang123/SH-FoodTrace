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
    public class LandBlockController : BaseController
    {
        private readonly ILandBlockService _landBlock;
        private readonly ILandBaseService _landBase;

        public LandBlockController(ILandBlockService landBlock,ILandBaseService landBase)
        {
            _landBlock = landBlock;
            _landBase = landBase;
        }

        // GET: /LandBlock/
        public ActionResult Index()
        {
            var landBaseList = _landBase.GetLandBaseListByType(1);

            ViewBag.LandBase = new SelectList(landBaseList, "LandID", "LandName");
            return View();
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetLandBlockList(int page, int rows)
        {
            var result = new GridList<LandBlockDto>();
            try
            {
                string blockName = RequestHelper.RequestPost("blockName", string.Empty);
                result = _landBlock.GetLandBlockPaging(blockName, page, rows);
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
        public JsonResult SaveLandBlock(LandBlockModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.BlockID == 0)
                {
                    _landBlock.InsertSingleLandBlock(model);
                }
                else
                {
                    _landBlock.UpdateSingleLandBlock(model);
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

        public JsonResult DeleteBlockByIds(string ids)
        {
            var result = new ResultJson();
            try
            {
                _landBlock.DeleteByIds(ids);
                result.IsSuccess = true;
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
        public JsonResult GetLandBlockById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _landBlock.GetLandBlockDtoById(id);
                result.IsSuccess = true;
            }
            catch (Exception)
            {
            }

            return Json(result);
        }
	}
}
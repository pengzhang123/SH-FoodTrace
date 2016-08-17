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
using FoodTrace.Service;
using Microsoft.Ajax.Utilities;
using Microsoft.SqlServer.Server;

namespace FoodTrace.WebSite.Controllers
{
    public class LandBaseController : BaseController
    {
        private readonly ILandBaseService _landBaseService;
        private readonly ICompanyService _companyService;
        public LandBaseController(ILandBaseService landBaseService,ICompanyService companyService)
        {
            _landBaseService = landBaseService;
            _companyService = companyService;
        }
        public ActionResult Index()
        {
            var companylist = _companyService.GetPagerCompany(string.Empty, 1, 100);
               
            //var model = new CompanyModel() {CompanyID = 0, CompanyName = "请选择"};
            //companylist.Insert(0,model);

            var data=companylist .Select(_ => new { CompanyName = _.CompanyName, CompanyID = _.CompanyID });
            ViewBag.CompanyList = new SelectList(data, "CompanyID", "CompanyName");
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
            var data = new GridList<LandBaseDto>();
            try
            {
                string landName = RequestHelper.RequestPost("landName", string.Empty);
                data = _landBaseService.GetLandBaseListPaging(page, rows, landName);
            }
            catch (Exception ex)
            {

            }
            return Json(data);
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetLandBaseById(int id)
        {
            var result = new ResultJson();
            try
            {
               var data = _landBaseService.GetLandBaseById(id);
                result.IsSuccess = true;
                result.Data = data;
            }
            catch (Exception)
            {
                
            }

            return JsonEx(result);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult DelLandBase(string ids)
        {
            var result = new ResultJson();
            try
            {
                var msg = _landBaseService.DelLandBaseByIds(ids);
                if(msg.Status==MessageStatus.Success)
                    result.IsSuccess = true;
            }
            catch (Exception)
            {
                
                throw;
            }

            return Json(result);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveLandBase(LandBaseModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.LandID == 0)
                {
                   msg= _landBaseService.InsertSingleLandBase(model);
                }
                else
                {
                    msg=_landBaseService.UpdateSingleLandBase(model);
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
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodTrace.Common.Libraries;
using FoodTrace.IService;
using FoodTrace.IService.SystemBase;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.WebSite.Controllers
{
    public class CompanyQSCardController : BaseController
    {
        private readonly ICompanyService _companyService;
        private readonly IQSCardService _qsCardService;
        public CompanyQSCardController(ICompanyService companyService,IQSCardService qsCardService)
        {
            _companyService = companyService;
            _qsCardService = qsCardService;
        }
        //
        // GET: /CompanyQSCard/
        public ActionResult Index()
        {
            var lstCompany = _companyService.GetPagerCompany(string.Empty, 1, 100);
            List<SelectListItem> companyList = new List<SelectListItem>();
            foreach (var item in lstCompany)
            {
                companyList.Add(new SelectListItem() { Text = item.CompanyName, Value = item.CompanyID.ToString() });
            }
            ViewBag.Company = companyList;
            return View();
        }

        /// <summary>
        /// 分页数据列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetQsCardList(int page, int rows)
        {
            var data = new GridList<QsCardDto>();
            try
            {
                string name = RequestHelper.RequestPost("qsName", string.Empty);
                var list = _qsCardService.GetQsCardPagingList(name, page, rows);
                data = list;
            }
            catch
            {

            }

            return JsonEx(data,"yyyy-MM-dd");
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public JsonResult SaveCardData(QSCardModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.QSID == 0)
                {
                   msg= _qsCardService.InsertQSCard(model);

                }
                else
                {
                   msg= _qsCardService.UpdateQSCard(model);
                }
                if (msg.Status == MessageStatus.Success)
                {
                    result.IsSuccess = true;
                }
            }
            catch 
            {

            }

            return Json(result);
        }

        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetQSCardByid(int id)
        {
            var result = new ResultJson();
            try
            {
                var data = _qsCardService.GetQsCardById(id);
                result.IsSuccess = true;
                result.Data = data;
            }
            catch (Exception)
            {

            }

            return JsonEx(result,"yyyy-MM-dd");
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public JsonResult DeleteQsCardByIds(string ids)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                msg = _qsCardService.DeleteByIds(ids);
                if (msg.Status == MessageStatus.Success)
                {
                    result.IsSuccess = true;
                }
            }
            catch
            {

            }

            return Json(result);
        }
	}
}
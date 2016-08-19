using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Tree;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.WebSite.Controllers.KillManage
{
    public class KillBatchDetailController : BaseController
    {
        //
        // GET: /KillBatchDetail/

        private readonly IKillBatchDetailService _batchDetailService;
        private readonly IKillBatchService _batchService;
        private readonly ICultivationBaseService _cultivationBaseService;
        private readonly IBreedAreaService _breedAreaService;
        private readonly IBreedBaseService _breedBaseService;
        private readonly IBreedHomeService _breedHomeService;
        public KillBatchDetailController(IKillBatchDetailService batchDetailService,IKillBatchService batchService,
            ICultivationBaseService cultivationBaseService, IBreedAreaService breedAreaService,
            IBreedBaseService breedBaseService,IBreedHomeService breedHomeService)
        {
            _batchDetailService = batchDetailService;
            _batchService = batchService;
            _cultivationBaseService = cultivationBaseService;
            _breedAreaService = breedAreaService;
            _breedBaseService = breedBaseService;
            _breedHomeService = breedHomeService;
        }
        public ActionResult Index()
        {
            //屠宰批次
            var killBatch = _batchService.GetKillBatchListPaging(1, 1000);
            ViewBag.KillBatch = new SelectList(killBatch.rows, "KillBatchID", "BatchNO");

            var cultivation = _cultivationBaseService.GetPagerCultivationBase(string.Empty, 1, 1000);
            ViewBag.Cultivation = new SelectList(cultivation, "CultivationID", "CultivationEPC");
            return View();
        }

        /// <summary>
        /// 根据养殖生物 获取相关养殖信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetBreedInfoByCultivationId(int id)
        {
            var result = new ResultJson();
            try
            {

                var cultivation = _cultivationBaseService.GetCultivationBaseById(id);
                if (cultivation != null)
                {
                    int breedId = 0,areaid=0,homeId=0;
                    if (cultivation.BreedID != null)
                    {
                        breedId = (int)cultivation.BreedID;
                    }
                    if (cultivation.AreaID != null)
                    {
                        areaid = (int) cultivation.AreaID;
                    }
                    if (cultivation.HomeID != null) 
                    {
                        homeId = (int) cultivation.HomeID;
                    }

                    var breedbase = _breedBaseService.GetBreedBaseById(breedId);
                    var home = _breedHomeService.GetBreedHomeById(homeId);
                    var area = _breedAreaService.GetBreedAreaById(areaid);

                    var breeddto = new ItemDto(); 
                    if (breedbase != null)
                    {
                        breeddto.id = breedbase.BreedID;
                        breeddto.name = breedbase.BreedName;
                    }
                    result.Items.Add("breedbase", breeddto);

                    var homedto = new ItemDto();
                    if (home != null)
                    {
                        homedto.id = home.HomeID;
                        homedto.name = home.HomeName;
                      
                    }
                    result.Items.Add("home", homedto);

                    var areadto = new ItemDto();
                    if (area != null)
                    {
                        areadto.id = area.AreaID;
                        areadto.name = area.AreaName;
                    }
                    result.Items.Add("area", areadto);
                    result.IsSuccess = true;
                }
                
              
            }
            catch (Exception)
            {
                
             
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        public JsonResult GetList(int page, int rows)
        {
            var data = new GridList<KillBatchDetailDto>();
            try
            {
                data = _batchDetailService.GetKillBatchDetailListPaging(string.Empty, page, rows);
            }
            catch (Exception)
            {
              
            }

            return Json(data);
        }

        public JsonResult SaveData(KillBatchDetailModel model)
        {
            var result = new ResultJson();
            try
            {
                var msg = new MessageModel();
                if (model.DetailID == 0)
                {
                    msg = _batchDetailService.InsertSingleKillBatchDetail(model);
                }
                else
                {
                    msg = _batchDetailService.UpdateSingleKillBatchDetail(model);
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
        public JsonResult GetBatchDetailById(int id)
        {
            var result = new ResultJson();
            try
            {
                result.Data = _batchDetailService.GetKillBatchDetalDtoById(id);
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
                var msg = new MessageModel();

                msg = _batchDetailService.DeleteByIds(ids);
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

    public class ItemDto
    {
        public ItemDto()
        {
            id = 0;
            name = string.Empty;
        }
        public int id { get; set; }

        public string name { get; set; }
    }
}
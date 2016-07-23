using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodTrace.IService;
using FoodTrace.Service;
using FoodTrace.Model;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FoodTrace.WebAPI.Controllers
{
    public class DefaultController : ApiController
    {

        // GET: api/Default/5
        /// <summary>
        /// 皮影
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <returns></returns>
        public string Get(string Epc, string OrCode)
        {
            if (!string.IsNullOrEmpty(Epc))
            {
                if (Epc.Length > 8) return "3";
                TidService tidService = new TidService();
                TIDModel tidModel = tidService.GetTidChipCode(Epc);
                if (tidModel == null) return "2";
            }

            IShadowBaseService shadowBaseService = new ShadowBaseService();
            ShadowBaseModel model = shadowBaseService.GetShawInfoByEPCOrORCode(Epc, OrCode);
            if (model == null) return "1";
            return JsonConvert.SerializeObject(new
            {
                ProductName = model.ProductName,
                ProductType = model.ProductType == null ? string.Empty : model.ProductType.ProductTypeEN,
                CompanyName = model.Company.CompanyName,
                AreaCode = model.Company.AreaCode,
                Address = model.Company.Address,
                Leader = model.Company.Leader,
                Logo = model.Company.Logo,
                Location = model.Company.Location,
                Code = model.Company.Code,
                ZipCode = model.Company.ZipCode,
                TaxCard = model.Company.TaxCard,
                Fax = model.Company.Fax,
                Mobile = model.Company.Mobile,
                Email = model.Company.Email,
                Info = model.Company.Info,
                Demand = model.Company.Demand,
                Price = model.Price,
                ProductCode = model.ProductCode,
                ShadowEPC = model.ShadowEPC,
                ORCode = model.ORCode,
                ChipCode = model.ChipCode,
                ProcessBatch = model.ProcessBatch,
                Method = model.Method,
                ProcessTime = model.ProcessTime,
                Temp = model.Temp,
                Dry = model.Dry,
                DryTime = model.DryTime,
                RawBatch = model.RawBatch,
                Flow = model.Flow,
                Reamrk = model.Remark,
                ShadowProcess = model.ShadowProcess==null?null: model.ShadowProcess.Select(m => new
                {
                    m.ProcessBase.ProcessCode,
                    m.ProcessBase.ProcessName
                })
            });
        }

        /// <summary>
        /// 养殖
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <returns></returns>
        public string GetBreed(string Epc, string OrCode)
        {
            ICultivationBaseService cultivationBaseService = new CultivationBaseService();
            CultivationBaseModel model = cultivationBaseService.GetCultivationInfoByEPCOrORCode(Epc, OrCode);
            if (model == null) return "";
            return JsonConvert.SerializeObject(new
            {
                BreedName = model.BreedBase == null ? string.Empty : model.BreedBase.BreedName,
                AreaName = model.BreedArea == null ? string.Empty : model.BreedArea.AreaName,
                HomeName = model.BreedHome == null ? string.Empty : model.BreedHome.HomeName,
                CultivationEpc = model.CultivationEpc,
                BatchCode = model.BatchCode,
                Source = model.Source,
                OutNotes = model.OutNotes
            });
        }

        /// <summary>
        /// 种植
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <returns></returns>
        public string GetPlants(string Epc, string OrCode)
        {
            IPlansBatchService plansBatchService = new PlansBatchService();
            PlansBatchModel model = plansBatchService.GetPlansBatchByEPCOrORCode(Epc, OrCode);
            if (model == null) return "";
            return JsonConvert.SerializeObject(new
            {
                BlockCode = model.LandBlock == null ? string.Empty : model.LandBlock.BlockCode,
                BlockName = model.LandBlock == null ? string.Empty : model.LandBlock.BlockName,
                SoilType = model.LandBlock == null ? string.Empty : model.LandBlock.SoilType,
                SoilName = model.LandBlock == null ? string.Empty : model.LandBlock.SoilName,
                SoilSalinity = model.LandBlock == null ? string.Empty : model.LandBlock.SoilSalinity,
                SoilQuality = model.LandBlock == null ? string.Empty : model.LandBlock.SoilQuality,

                SeedCode = model.SeedBase == null ? string.Empty : model.SeedBase.SeedCode,
                SeedNO = model.SeedBase == null ? string.Empty : model.SeedBase.SeedNO,
                SeedName = model.SeedBase == null ? string.Empty : model.SeedBase.SeedName,
                BatchNO = model.SeedBase == null ? string.Empty : model.SeedBase.BatchNO,
                Place = model.SeedBase == null ? string.Empty : model.SeedBase.Place,
                Supplier = model.SeedBase == null ? string.Empty : model.SeedBase.Supplier,
                PurchPerson = model.SeedBase == null ? string.Empty : model.SeedBase.PurchPerson,
                BuyTime = model.SeedBase == null ? null : model.SeedBase.BuyTime,
                Units = model.SeedBase == null ? string.Empty : model.SeedBase.Units,

                BatchCode = model.BatchCode,
                PlansTime = model.PlansTime,
                PlansYear = model.PlansYear
            });
        }

        /// <summary>
        /// 屠宰
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <returns></returns>
        public string GetKill(string Epc, string OrCode)
        {
            IKillCullService killCullService = new KillCullService();
            KillCullModel model = killCullService.GetKillCullByEPCOrORCode(Epc, OrCode);
            if (model == null) return "";
            return JsonConvert.SerializeObject(new
            {
                CompanyName = model.Company == null ? string.Empty : model.Company.CompanyName,
                RecvicePeople = model.KillBatch == null ? string.Empty : model.KillBatch.RecvicePeople,
                BatchNO = model.KillBatch == null ? string.Empty : model.KillBatch.BatchNO,
                KillEpc =  model.KillEpc,
                CultivationEpc = model.CultivationEpc,
                ProductName = model.ProductName,
                Weight = model.Weight,
                Flow = model.Flow,
                KillTime = model.KillTime
            });
        }

        /// <summary>
        /// 物流
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <returns></returns>
        public string GetTrun(string Epc, string OrCode)
        {
            ITrunApplyDetailService trunApplyDetailService = new TrunApplyDetailService();
            TrunApplyDetailModel model = trunApplyDetailService.GetTrunApplyDetailByEPCOrORCode(Epc, OrCode);
            if (model == null) return "";
            return JsonConvert.SerializeObject(new
            {
                CompanyName = model.TrunApply.Company == null ? string.Empty : model.TrunApply.Company.CompanyName,
                DriverName = model.TrunApply.TrunDriver == null ? string.Empty : model.TrunApply.TrunDriver.DriverName,
                CarNo = model.TrunApply.TrunVehicle == null ? string.Empty : model.TrunApply.TrunVehicle.CarNo,
                CarCode = model.TrunApply.TrunVehicle == null ? string.Empty : model.TrunApply.TrunVehicle.CarCode,
                CarSize = model.TrunApply.TrunVehicle == null ? string.Empty : model.TrunApply.TrunVehicle.CarSize,
                ProductName = model.ProductName,
                TrunEPC = model.TrunEPC
            });
        }

        /// <summary>
        /// 销售
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <returns></returns>
        public string GetSale(string Epc, string OrCode)
        {
            ISaleBaseService saleBaseService = new SaleBaseService();
            SaleBaseModel model = saleBaseService.GetSaleBaseByEPCOrORCode(Epc, OrCode);
            if (model == null) return "";
            return JsonConvert.SerializeObject(new
            {
                CompanyName = model.Company == null ? string.Empty : model.Company.CompanyName,
                WareHouseEPC = model.WareHouseEPC,
                SaleEPC = model.SaleEPC,
                ORCode = model.ORCode,
                ChipCode = model.ChipCode,
                ProductName = model.ProductName,
                ClassName = model.ClassName,
                ProductCode = model.ProductCode,
                Weight = model.Weight,
                Price = model.Price,
                PinYingCode = model.PinYingCode,
                SaleTime = model.SaleTime
            });
        }

        /// <summary>
        /// 加工
        /// </summary>
        /// <param name="Epc"></param>
        /// <param name="OrCode"></param>
        /// <returns></returns>
        public string GetProcess(string Epc, string OrCode)
        {
            IProcessProductService processProductService = new ProcessProductService();
            ProcessProductModel model = processProductService.GetProcessProductByEPCOrORCode(Epc, OrCode);
            if (model == null) return "";
            return JsonConvert.SerializeObject(new
            {
                ProductName = model.ProductName,
                ClassID = model.ClassID,
                ProcessEPC = model.ProcessEPC,
                People = model.People,
                ProductTypeName = model.ProductTypeName,
                Price = model.Price,
                ProductCode = model.ProductCode,
                OrCode = model.OrCode,
                ChipCode = model.ChipCode,
                Level = model.Level,
                ISO = model.ISO,
                Info = model.Info,
                Weight = model.Weight,
                Package = model.Package,
                Flow = model.Flow,
                PackgeNum = model.PackgeNum,
                PackageTime = model.PackageTime,
                Life = model.Life
            });
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}

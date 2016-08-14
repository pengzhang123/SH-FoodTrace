using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.IDBAccess.ProdcutTraceApi;
using FoodTrace.Model;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class ProductTraceApiAccess:BaseAccess,IProductTraceApiAccess
    {
        //http://192.168.1.104:8008/uploadfile/test/test.png

        private readonly string _ImageUrl = "";
        /// <summary>
        /// 根据epc获取orcode获取产品基本信息数据
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        public CultivationDto GetProductByEpcOrCode(string epc, string orCode)
        {
            var model = new CultivationDto();
            //string result = string.Empty;
            var productBase = GetProProductByEpc(epc, orCode);
            if (productBase != null)
            {
                var product = (from s in Context.ProductBase
                               join pt in Context.ProductType on s.ProductTypeID equals pt.ProductTypeID
                               join ps in Context.ProductSpec on s.ProductSpcID equals ps.SPCID
                               where s.ProductID == productBase.PProductID
                               select new ProductInfoDto
                               {
                                   Code = s.ProductID,
                                   Name = s.ProductName,
                                   TypeName = pt.ProductTypeEN,
                                   SourceName = "",
                                   SpecName = ps.SpecName,
                                   Price = s.Price,
                                   Weight = s.Weight
                               }).FirstOrDefault();

                var company = (from com in Context.Company
                               join pro in Context.ProcessBatch on com.CompanyID equals pro.CompanyID
                               join prod in Context.ProcessBatchDetail on pro.PApplyID equals prod.PApplyID
                               where prod.ProcessEPC == productBase.ProcessEPC
                               select com).FirstOrDefault();

                if (product != null)
                {
                    product.ShelfLife = productBase.Life;
                    product.Type = 1;
                    if (company != null)
                    {
                        product.QsNum = company.QsCode;
                        product.CompanyName = company.CompanyName;
                    }
                    //基本信息
                    model.ProductInfoDto = product;
                    //溯源结构  ProductCode 养殖:10,种植:30
                    var productPreCode = productBase.ProductCode.Substring(0, 2);
                    if (productPreCode == "10")
                    {
                        var productTrace = GetProductTrace(epc, orCode);
                        model.ProductTraceDto = productTrace;
                        model.Type = 1;
                    }
                    else
                    {
                        var productTrace = GetProductPlantTrace(epc, orCode);
                        model.ProductTraceDto = productTrace;
                        model.Type = 3;
                    }

                    return model;
                }
            }

            return null;
        }


        /// <summary>
        /// 肉类溯源
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        public List<ProductTraceDto> GetProductTrace(string epc, string orCode)
        {
            var list = new List<ProductTraceDto>();

            var productBase = GetProProductByEpc(epc, orCode);
            if (productBase != null)
            {
                var model = new ProductTraceDto() { Type = 6 };
                //销售仓库
                var warehouse = (from s in Context.ProductBase
                                 join stock in Context.WareHouseStock on s.ProductID equals stock.ProductID
                                 join ware in Context.WareHouseBase on stock.WareHouseID equals ware.WareHouseID
                                 where s.ProductID == productBase.ProductID
                                 select new ProductTraceDto()
                                 {
                                     Code = ware.WareHouseID,
                                     Name = ware.WareHouseName,
                                     Type = 6,
                                     Image = _ImageUrl
                                 }).FirstOrDefault();

                if (warehouse != null)
                {
                    model = warehouse;
                    var details = GetSaleCompanyWarehouse(warehouse.Code, epc, orCode);
                    model.DetailData = details;
                }
                list.Add(model);
                //销售公司
                var baseSale = GetSaleBaseByEpc(epc, orCode);
                if (baseSale != null)
                {
                    var saleModel = new ProductTraceDto() { Type = 7 };
                    var saleCompany = (from com in Context.Company
                                       where com.CompanyID == baseSale.CompanyID
                                       select new ProductTraceDto
                                       {
                                           Code = com.CompanyID,
                                           Name = com.CompanyName,
                                           Type = 7,
                                           Image = _ImageUrl
                                       }).FirstOrDefault();

                    if (saleCompany != null)
                    {
                        saleModel = saleCompany;
                        var details = GetSaleCompany(saleCompany.Code);
                        saleModel.DetailData = details;
                    }
                    list.Add(saleModel);
                }


                //加工厂
                var processModel = new ProductTraceDto() { Type = 5 };
                var procFactory = (from com in Context.Company
                                   join batch in Context.ProcessBatch on com.CompanyID equals batch.CompanyID
                                   join batchd in Context.ProcessBatchDetail on batch.PApplyID equals batchd.PApplyID
                                   where batchd.ProcessEPC == productBase.ProcessEPC
                                   select new ProductTraceDto()
                                   {
                                       Code = com.CompanyID,
                                       Name = com.CompanyName,
                                       Type = 5,
                                       Image = _ImageUrl
                                   }).FirstOrDefault();

                if (procFactory != null)
                {
                    processModel = procFactory;
                    var details = GetProcessFactory(procFactory.Code, epc, orCode);
                    processModel.DetailData = details;
                }
                list.Add(processModel);

                //屠宰场
                var killModel = new ProductTraceDto() { Type = 3 };
                var killFatory = (from com in Context.Company
                                  join k in Context.KillCull on com.CompanyID equals k.CompanyID
                                  where k.KillEpc == productBase.ProcessEPC
                                  select new ProductTraceDto()
                                  {
                                      Code = k.KillCullID,
                                      Name = com.CompanyName,
                                      Type = 3,
                                      Image = _ImageUrl
                                  }).FirstOrDefault();

                if (killFatory != null)
                {
                    killModel = killFatory;
                    var details = GetKillFactory(killFatory.Code, epc, orCode);
                    killModel.DetailData = details;
                }
                list.Add(killModel);

                //养殖场
                var culModel = new ProductTraceDto() { Type = 2 };
                var cultivate = (
                                from b in Context.BreedBase
                                join c in Context.CultivationBase on b.BreedID equals c.BreedID
                                join kill in Context.KillCull on c.CultivationEpc equals kill.CultivationEpc
                                where kill.KillEpc == productBase.ProcessEPC
                                select new ProductTraceDto()
                                {
                                    Code = c.CultivationID,
                                    Name = b.BreedName,
                                    Type = 2,
                                    Image = _ImageUrl
                                }).FirstOrDefault();

                if (cultivate != null)
                {
                    culModel = cultivate;
                    var details = GetCultivation(cultivate.Code, epc, orCode);
                    culModel.DetailData = details;
                }
                list.Add(culModel);

                //个体
                var unitModel = new ProductTraceDto() { Type = 1 };
                var unit = (from c in Context.CultivationBase
                            join kill in Context.KillCull on c.CultivationEpc equals kill.CultivationEpc
                            where kill.KillEpc == productBase.ProcessEPC
                            select new ProductTraceDto()
                            {
                                Code = c.CultivationID,
                                Name = c.VarietyName,
                                Type = 1,
                                Image = _ImageUrl
                            }).FirstOrDefault();

                if (unit != null)
                {
                    unitModel = unit;
                    var details = GetTraceUint(unit.Code);
                    unitModel.DetailData = details;
                }
                list.Add(unitModel);

                //母
                var mModel = new ProductTraceDto() { Type = 10 };
                //var fModel = new ProductTraceDto() { Type = 9 };
                var unitParent = (from c in Context.CultivationBase
                                  join kill in Context.KillCull on c.CultivationEpc equals kill.CultivationEpc
                                  where kill.KillEpc == productBase.ProcessEPC
                                  select c).FirstOrDefault();
                if (unitParent != null)
                {
                    var parentMother = (from c in Context.CultivationBase
                                        where c.CultivationID == unitParent.MontherID
                                        select new ProductTraceDto()
                                        {
                                            Code = c.CultivationID,
                                            Name = c.VarietyName,
                                            Type = 10,
                                            Image = _ImageUrl
                                        }).FirstOrDefault();
                    if (parentMother != null)
                    {
                        mModel = parentMother;
                        var details = GetTraceUint(parentMother.Code);
                        mModel.DetailData = details;
                    }


                }
                list.Add(mModel);
                //list.Add(fModel);
            }
            return list;
        }


        /// <summary>
        /// 种植流程追溯
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        public List<ProductTraceDto> GetProductPlantTrace(string epc, string orCode)
        {
            var list = new List<ProductTraceDto>();

            var productBase = GetProProductByEpc(epc, orCode);
            if (productBase != null)
            {
                var model = new ProductTraceDto() { Type = 6 };
                //销售仓库
                var warehouse = (from s in Context.ProductBase
                                 join stock in Context.WareHouseStock on s.ProductID equals stock.ProductID
                                 join ware in Context.WareHouseBase on stock.WareHouseID equals ware.WareHouseID
                                 where s.ProductID == productBase.ProductID
                                 select new ProductTraceDto()
                                 {
                                     Code = ware.WareHouseID,
                                     Name = ware.WareHouseName,
                                     Type = 6,
                                     Image = ""
                                 }).FirstOrDefault();

                if (warehouse != null)
                {
                    model = warehouse;
                    var details = GetSaleCompanyWarehouse(warehouse.Code, epc, orCode);
                    model.DetailData = details;
                }
                list.Add(model);
                //销售公司
                var baseSale = GetSaleBaseByEpc(epc, orCode);
                if (baseSale != null)
                {
                    var saleModel = new ProductTraceDto() { Type = 7 };
                    var saleCompany = (from com in Context.Company
                                       where com.CompanyID == baseSale.CompanyID
                                       select new ProductTraceDto
                                       {
                                           Code = com.CompanyID,
                                           Name = com.CompanyName,
                                           Type = 7,
                                           Image = ""
                                       }).FirstOrDefault();

                    if (saleCompany != null)
                    {
                        saleModel = saleCompany;
                        var details = GetSaleCompany(saleCompany.Code);
                        saleModel.DetailData = details;
                    }
                    list.Add(saleModel);
                }


                //加工厂
                var processModel = new ProductTraceDto() { Type = 5 };
                var procFactory = (from com in Context.Company
                                   join batch in Context.ProcessBatch on com.CompanyID equals batch.CompanyID
                                   join batchd in Context.ProcessBatchDetail on batch.PApplyID equals batchd.PApplyID
                                   where batchd.ProcessEPC == productBase.ProcessEPC
                                   select new ProductTraceDto()
                                   {
                                       Code = com.CompanyID,
                                       Name = com.CompanyName,
                                       Type = 5,
                                       Image = ""
                                   }).FirstOrDefault();

                if (procFactory != null)
                {
                    processModel = procFactory;
                    var details = GetProcessFactory(procFactory.Code,epc,orCode);
                    processModel.DetailData = details;
                }
                list.Add(processModel);

                //种植基地
                var plantModel = new ProductTraceDto() { Type = 11 };
                var plantFactory = (from lbase in Context.LandBase
                                    join lb in Context.LandBlock on lbase.LandID equals lb.LandID
                                    join pb in Context.PlansBatch on lb.BlockID equals pb.BlockID
                                    where pb.BatchCode == productBase.ProcessEPC
                                    select new ProductTraceDto()
                                    {
                                        Code = lbase.LandID,
                                        Name = lbase.LandName,
                                        Type = 2,
                                        Image = ""
                                    }).FirstOrDefault();
                if (plantFactory != null)
                {
                    plantModel = plantFactory;
                    var details = GetPlantModeL(productBase.ProcessEPC);
                    plantModel.DetailData = details;
                }
                list.Add(plantModel);

                //种子
                var seedModel = new ProductTraceDto() { Type = 12 };
                var seed = (from s in Context.SeedBase
                            join pb in Context.PlansBatch on s.SeedID equals pb.SeedID
                            where pb.BatchCode == productBase.ProcessEPC
                            select new ProductTraceDto()
                            {
                                Code = s.SeedID,
                                Name = s.SeedName,
                                Type = 12,
                                Image = ""
                            }).FirstOrDefault();
                if (seed != null)
                {
                    seedModel = seed;
                    var details = GetSeedModel(seed.Code);
                    seedModel.DetailData = details;
                }
                list.Add(seedModel);
            }

            return list;
        }


        /// <summary>
        /// 根据epc和二维码获取产品基本信息
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        private ProcessProductModel GetProProductByEpc(string epc, string orCode)
        {
            var query = Context.ProcessProduct.AsQueryable();
            if (!string.IsNullOrEmpty(epc))
            {
                query = query.Where(s => s.ChipCode == epc);
            }
            if (!string.IsNullOrEmpty(orCode))
            {
                query = query.Where(s => s.OrCode == orCode);
            }

            return query.FirstOrDefault();
        }

        /// <summary>
        /// 根据epc获取销售
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        private SaleBaseModel GetSaleBaseByEpc(string epc, string orCode)
        {
            var query = Context.SaleBase.AsQueryable();
            if (!string.IsNullOrEmpty(epc))
            {
                query = query.Where(s => s.ChipCode == epc);
            }
            if (!string.IsNullOrEmpty(orCode))
            {
                query = query.Where(s => s.ORCode == orCode);
            }

            return query.FirstOrDefault();
        }


        /// <summary>
        /// 获取公司信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private object GetSaleCompany(int code)
        {
          
            var query = (from s in Context.Company
                         join qs in Context.QSCard on s.CompanyID equals qs.CompanyID
                         where s.CompanyID == code
                         select new
                         {
                             CompanyName = s.CompanyName,
                             Address = s.Address,
                             IssunigTime = qs.IssuingTime,
                             IssuigUnit = qs.IssuingUnit,
                             Validity = qs.Validity,
                             ValidityImage = "",
                             QsNum = qs.QSCard
                         }).FirstOrDefault();

            return query;
        }

        /// <summary>
        /// 获取产品仓库信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="epc"></param>
        /// <param name="orcode"></param>
        /// <returns></returns>
        private object GetSaleCompanyWarehouse(int code, string epc, string orcode)
        {

            var productBase = GetProProductByEpc(epc, orcode);
            if (productBase != null)
            {
                var query = (from wb in Context.WareHouseBase
                             join wd in Context.WareHouseDetail on wb.WareHouseID equals wd.WareHouseID
                             where wd.ProductID == productBase.ProductID
                             select new
                             {
                                 WareHouseName = wb.WareHouseName,
                                 Address = wb.WareHouseAddress,
                                 WareTemp = wd.WareTemp,
                                 WareWet = wd.WareWet,
                                 InWareTime = wd.InWareTime,
                                 OutWareTime = wd.OutWareTime,
                                 // WareImage = ""
                             }).FirstOrDefault();

                return query;
            }
            return null;
        }

        /// <summary>
        /// 加工厂
        /// </summary>
        /// <param name="code"></param>
        /// <param name="epc"></param>
        /// <param name="orcode"></param>
        /// <returns></returns>
        private object GetProcessFactory(int code, string epc, string orcode)
        {
          
            var productBase = GetProProductByEpc(epc, orcode);
            if (productBase != null)
            {
                var factory = Context.Company.FirstOrDefault(s => s.CompanyID == code);
                string name = factory == null ? "" : factory.CompanyName;
                var query = (from p in Context.ProductBase
                             join b in Context.ProductSpec on p.ProductSpcID equals b.SPCID
                             //join bd in Context.ProductType on p.ProductTypeID equals bd.ProductTypeID
                             where p.ProductID == productBase.ProductID
                             select new
                             {
                                 FactoryName = name,
                                 ProductName = p.ProductName,
                                 ProcessMethod = "",
                                 ProcessBatch = productBase.ProcessBatch,
                                 ProcessTime = "",
                                 ProductClass = b.ClassName,
                                 ProductSpec = b.SpecName,
                                 Weight = p.Weight,
                                 // ProcessImage="",
                             }).FirstOrDefault();

                return query;
            }


            return null;
        }

        /// <summary>
        /// 获取屠宰场信息
        /// </summary>
        /// <returns></returns>
        private object GetKillFactory(int code, string epc, string orcode)
        {
            //string result = string.Empty;

            //var baseProduct = GetProProductByEpc(epc, orcode);
            //if (baseProduct != null)
            //{
            var query = (from k in Context.KillCull
                         join kd in Context.KillDrug on k.KillCullID equals kd.KillCullID
                         join c in Context.Company on k.CompanyID equals c.CompanyID
                         where k.KillCullID == code
                         select new
                         {
                             FactoryName = c.CompanyName,
                             Address = c.Address,
                             Flow = k.Flow,
                             KillBatch = k.KillBatchID,
                             Weight = k.Weight,
                             KillTime = k.KillTime,
                             CheckMan = kd.People,
                             DrugTime = kd.DrugTime
                         }).FirstOrDefault();
            //}
            return query;
        }

        /// <summary>
        /// 养殖场
        /// </summary>
        /// <param name="code"></param>
        /// <param name="epc"></param>
        /// <param name="orcode"></param>
        /// <returns></returns>
        public object GetCultivation(int code, string epc, string orcode)
        {
           
            var query = (from cb in Context.CultivationBase
                         join b in Context.BreedBase on cb.BreedID equals b.BreedID
                         join bd in Context.BreedDrug on cb.CultivationID equals bd.CultivationID
                         join bh in Context.BreedHome on cb.AreaID equals bh.AreaID
                         join bm in Context.BreedMaterial on cb.CultivationID equals bm.CultivationID
                         join bheal in Context.BreedHealth on cb.CultivationID equals bheal.CultivationID
                         join lb in Context.LandBase on b.LandID equals lb.LandID
                         where cb.CultivationID == code
                         select new
                         {
                             BreedName = b.BreedName,
                             BreedArea = b.BreedArea,
                             Address = lb.Address,
                             BreedHealth = bh.HealthStatus,
                             MarterialName = bm.MaterialName,
                             BreedBatch = cb.BatchCode,
                             UnitHealth = bheal.HealthState,
                             DrugTime = bd.DrugTime,
                             DrugName = bd.DrugName
                         }).FirstOrDefault();

            return query;
        }

        /// <summary>
        /// 个体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public object GetTraceUint(int code)
        {
            var query = (from cb in Context.CultivationBase
                         join kill in Context.KillCull on cb.CultivationID equals kill.CultivationID
                         join bm in Context.BreedMaterial on cb.CultivationID equals bm.CultivationID
                         join bd in Context.BreedDrug on cb.CultivationID equals bd.DrugID
                         where cb.CultivationID == code
                         select new
                         {
                             VarietyName = cb.VarietyName,
                             InTime = cb.InTime,
                             KilTime = kill.KillTime,
                             BreedBatch = cb.BatchCode,
                             MaterialName = bm.MaterialName,
                             MaterialType = bm.MaterialType,
                             MaterialMethod = bm.Method,
                             MaterialCot = bm.MaterialCot,
                             DrugName = bd.DrugName,
                             DrugTime = bd.DrugTime,
                             DrugObject = bd.Object
                         }).FirstOrDefault();

            return query;
        }

        /// <summary>
        /// 种植地块信息
        /// </summary>
        /// <param name="epc"></param>
        /// <returns></returns>
        public object GetPlantModeL(string epc)
        {
            var query = (from lbase in Context.LandBase
                join lb in Context.LandBlock on lbase.LandID equals lb.LandID
                join pb in Context.PlansBatch on lb.BlockID equals pb.BlockID
                where pb.BatchCode == epc
                select new
                {
                    LandName=lbase.LandName,
                    LandArea=lbase.LandArea,
                    BlockName=lb.BlockName,
                    BlockArea=lb.BlockArea,
                    EnployeNum=lbase.EmployeesNum,
                    Address=lbase.Address,
                    SoilType = lb.SoilType,
                    SoilName=lb.SoilName,
                }).FirstOrDefault();

            return query;
        }

        /// <summary>
        /// 获取种子信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public object GetSeedModel(int code)
        {
            var query = (from s in Context.SeedBase
                join pb in Context.PlansBatch on s.SeedID equals pb.SeedID
                where s.SeedID==code
                select new
                {
                    SeedName=s.SeedName,
                    SeedBatchNum=s.BatchNO,
                    Place=s.Place,
                    Supplier=s.Supplier,
                    PurchMan=s.PurchPerson,
                    Count=s.BuyTime,
                    PlanTime=pb.PlansTime,
                    PlanArea=pb.PlansArea
                }).FirstOrDefault();

            return query;
        }
    }
}

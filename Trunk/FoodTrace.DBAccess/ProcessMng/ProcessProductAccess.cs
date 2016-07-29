using System.Data.Entity.Core;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using FoodTrace.Common.Libraries;
using FoodTrace.Common.Log;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.DtoModel;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace FoodTrace.DBAccess
{
    public class ProcessProductAccess : BaseAccess, IProcessProductAccess
    {
        public int GetEntityCount()
        {
            return base.Context.ProcessProduct.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.ProcessProduct.Where(m => m.ProcessBatchDetail.ProcessBatch.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.ProcessEPC.Contains(code))).Count();
        }

        public List<ProcessProductModel> GetAllEntities()
        {
            return base.Context.ProcessProduct.ToList();
        }

        public ProcessProductModel GetEntityById(int id)
        {
            return base.Context.ProcessProduct.FirstOrDefault(m => m.PProductID == id);
        }

        public MessageModel InsertSingleEntity(ProcessProductModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.ProcessProduct.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public ProcessProductModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.ProcessProduct.FirstOrDefault(m => m.PProductID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(ProcessProductModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.ProcessProduct.FirstOrDefault(m => m.PProductID == model.PProductID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.DetailID = model.DetailID;
                data.ProductID = model.ProductID;
                data.People = model.People;
                data.ProcessEPC = model.ProcessEPC;
                data.ClassID = model.ClassID;
                data.ProductName = model.ProductName;
                data.ProductTypeName = model.ProductTypeName;
                data.Price = model.Price;
                data.ProductCode = model.ProductCode;
                data.ShadowEPC = model.ShadowEPC;
                data.OrCode = model.OrCode;
                data.ChipCode = model.ChipCode;
                data.Level = model.Level;
                data.ISO = model.ISO;
                data.Info = model.Info;
                data.ProcessBatch = model.ProcessBatch;
                data.Weight = model.Weight;
                data.Package = model.Package;
                data.Flow = model.Flow;
                data.PackgeNum = model.PackgeNum;
                data.PackageTime = model.PackageTime;
                data.Life = model.Life;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.ModifyID = UserManagement.CurrentUser.UserID;
                data.ModifyName = UserManagement.CurrentUser.UserName;
                data.ModifyTime = DateTime.Now;
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                if (context.PlansBatch.Any(m => m.BlockID == id)) return "该地块信息存在关联数据，不能被删除！";

                var data = Context.ProcessProduct.FirstOrDefault(m => m.PProductID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<ProcessProductModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<ProcessProductModel> GetPagerProcessProductByConditions(int companyID, string applyNo, int pageIndex, int pageSize)
        {
            return base.Context.ProcessProduct.Where(m => m.ProcessBatchDetail.ProcessBatch.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(applyNo) || m.ProcessEPC.Contains(applyNo)))
                     .OrderBy(m => m.PProductID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public ProcessProductModel GetProcessProductByEPCOrORCode(string Epc, string OrCode)
        {
            return Context.ProcessProduct.FirstOrDefault(m => (string.IsNullOrEmpty(Epc) || m.ProcessEPC == Epc)||(string.IsNullOrEmpty(OrCode) || m.OrCode == OrCode));
        }

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
        /// 根据epc获取orcode获取产品基本信息数据
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        public ProductInfoDto GetProductByEpcOrCode(string epc, string orCode)
        {
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

                    return product;
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

            var productBase = GetProProductByEpc(epc,orCode);
            if (productBase != null)
            {
                var model =new ProductTraceDto(){Type = 6};
                //销售仓库
                var warehouse = (from s in Context.ProductBase
                    join stock in Context.WareHouseStock on s.ProductID equals stock.ProductID
                    join ware in Context.WareHouseBase on stock.WareHouseID equals ware.WareHouseID
                    where s.ProductID==productBase.ProductID
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
                }
                list.Add(model);
                //销售公司
                var baseSale = GetSaleBaseByEpc(epc, orCode);
                if (baseSale != null)
                {
                    var saleModel = new ProductTraceDto() {Type = 7};
                  var saleCompany = (from com in Context.Company
                                     where com.CompanyID == baseSale.CompanyID
                             select new ProductTraceDto
                              {
                                    Code = com.CompanyID,
                                    Name = com.CompanyName,
                                     Type= 7,
                                     Image = ""
                              }).FirstOrDefault();
                                     
                    if (saleCompany != null)
                    {
                        saleModel = saleCompany;
                    }
                    list.Add(saleModel);
                }
               

                //加工厂
                var processModel = new ProductTraceDto() { Type = 5 };
                var procFactory = ( from  com in Context.Company
                    join batch in Context.ProcessBatch on com.CompanyID equals batch.CompanyID
                    join batchd in Context.ProcessBatchDetail on batch.PApplyID equals batchd.PApplyID
                    where batchd.ProcessEPC== productBase.ProcessEPC
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
                }
                list.Add(processModel);

                //屠宰场
                var killModel = new ProductTraceDto() {Type = 3};
                var killFatory = (from com in Context.Company
                    join k in Context.KillCull on com.CompanyID equals k.CompanyID
                    where k.KillEpc == productBase.ProcessEPC
                    select new ProductTraceDto()
                    {
                        Code = com.CompanyID,
                        Name = com.CompanyName,
                        Type = 3,
                        Image = ""
                    }).FirstOrDefault();

                if (killFatory != null)
                {
                    killModel = killFatory;
                }
                list.Add(killModel);

                    //养殖场
                var culModel = new ProductTraceDto() {Type = 2};
                var cultivate = (
                                from b in Context.BreedBase 
                                join c in Context.CultivationBase on b.BreedID equals c.BreedID
                                join kill in Context.KillCull on c.CultivationEpc equals  kill.CultivationEpc
                               where kill.KillEpc == productBase.ProcessEPC
                    select new ProductTraceDto()
                    {
                        Code = c.CultivationID,
                        Name = b.BreedName,
                        Type = 2,
                        Image = ""
                    }).FirstOrDefault();

                if (cultivate != null)
                {
                    culModel = cultivate;
                }
                list.Add(culModel);

                //个体
                var unitModel = new ProductTraceDto() {Type = 1};
                var unit = (from c in Context.CultivationBase
                            join kill in Context.KillCull on c.CultivationEpc equals  kill.CultivationEpc
                               where kill.KillEpc == productBase.ProcessEPC
                    select new ProductTraceDto()
                    {
                        Code = c.CultivationID,
                        Name = c.VarietyName,
                        Type = 1,
                        Image = ""
                    }).FirstOrDefault();

                if (unit != null)
                {
                    unitModel = unit;
                }
                list.Add(unitModel);

                //母
                var mModel = new ProductTraceDto() {Type = 10};
                //var fModel = new ProductTraceDto() { Type = 9 };
                var unitParent = (from c in Context.CultivationBase
                    join kill in Context.KillCull on c.CultivationEpc equals kill.CultivationEpc
                    where kill.KillEpc == productBase.ProcessEPC
                    select c).FirstOrDefault();
                if (unitParent != null)
                {
                    var parentMother=(from c in Context.CultivationBase
                                where c.CultivationID==unitParent.MontherID
                                 select new ProductTraceDto()
                                 {
                                     Code = c.CultivationID,
                                     Name = c.VarietyName,
                                     Type = 10,
                                     Image = ""
                                 }).FirstOrDefault();
                    if (parentMother != null)
                    {
                        mModel = parentMother;
                    }
    
                    ////父
                  
                    //var parentFather = (from c in Context.CultivationBase
                    //                    where c.CultivationID == unitParent.FatherID
                    //                    select new ProductTraceDto()
                    //                    {
                    //                        Code = c.CultivationID,
                    //                        Name = c.VarietyName,
                    //                        Type = 9,
                    //                        Image = ""
                    //                    }).FirstOrDefault();
                    //if (parentFather != null)
                    //{
                    //    fModel = parentFather;
                    //}
                 
                }
                list.Add(mModel);
                //list.Add(fModel);
            }
            return list;
        }


        /// <summary>
        /// 根据不同的类型返回不同的实体数据
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <param name="code"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetProductTraceDetail(string epc,string orCode,int code,int type)
        {
            string result = string.Empty;

            try
            {
            switch (type)
            {
                case 1:
                case 9:
                case 10:
                    result = GetTraceUint(code);
                    break;
                case 2:
                    result = GetCultivation(code,epc,orCode);
                    break;
                case 3:
                    result =GetKillFactory(code,epc,orCode);
                    break;
                case 4:
                    result = "";
                    break;
                case 5:
                    result = GetProcessFactory(code,epc,orCode);
                    break;
                case 6:
                    result = GetSaleCompanyWarehouse(code,epc,orCode);
                    break;
                case 7:
                    result = GetSaleCompany(code);
                    break;

            }
            }
            catch (Exception ex)
            {
              Logger.Error(ex.ToString());
            }

            return result;
        }

        /// <summary>
        /// 获取公司信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private string GetSaleCompany(int code)
        {
            string result = string.Empty;
            var query =(from s in Context.Company
                        join qs in Context.QSCard on s.CompanyID equals qs.CompanyID
                        where s.CompanyID==code
                        select new
                        {
                            CompanyName=s.CompanyName,
                            Address=s.Address,
                            IssunigTime=qs.IssuingTime,
                            IssuigUnit=qs.IssuingUnit,
                            Validity=qs.Validity,
                            ValidityImage="",
                            QsNum=qs.QSCard
                        }).FirstOrDefault();

            if (query != null)
            {
                result = JsonConvert.SerializeObject(query);
            }
            return result;
        }

        /// <summary>
        /// 获取产品仓库信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="epc"></param>
        /// <param name="orcode"></param>
        /// <returns></returns>
        private string GetSaleCompanyWarehouse(int code, string epc, string orcode)
        {
            string result = string.Empty;

            var productBase = GetProProductByEpc(epc,orcode);
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

                if (query != null)
                {
                    result = JsonConvert.SerializeObject(query);
                }
            }
            return result;
        }

        /// <summary>
        /// 加工厂
        /// </summary>
        /// <param name="code"></param>
        /// <param name="epc"></param>
        /// <param name="orcode"></param>
        /// <returns></returns>
        private string GetProcessFactory(int code, string epc, string orcode)
        {
            string result = string.Empty;

            var productBase = GetProProductByEpc(epc, orcode);
            if (productBase != null)
            {
                var factory = Context.Company.FirstOrDefault(s=>s.CompanyID==code);
                string name = factory == null ? "" : factory.CompanyName;
                var query = (from p in Context.ProductBase
                             join b in Context.ProductSpec on p.ProductSpcID equals b.SPCID
                             //join bd in Context.ProductType on p.ProductTypeID equals bd.ProductTypeID
                             where p.ProductID==productBase.ProductID
                             select new
                             {
                                 FactoryName =name,
                                 ProductName = p.ProductName,
                                 ProcessMethod = "",
                                 ProcessBatch = productBase.ProcessBatch,
                                 ProcessTime="",
                                 ProductClass=b.ClassName,
                                 ProductSpec=b.SpecName,
                                 Weight=p.Weight,
                                // ProcessImage="",
                             }).FirstOrDefault();

                if (query != null)
                {
                    result = JsonConvert.SerializeObject(query);
                }
            }


            return result;
        }

        /// <summary>
        /// 获取屠宰场信息
        /// </summary>
        /// <returns></returns>
        private string GetKillFactory(int code,string epc,string orcode)
        {
            string result = string.Empty;

            //var baseProduct = GetProProductByEpc(epc, orcode);
            //if (baseProduct != null)
            //{
                var query = (from k in Context.KillCull
                    join kd in Context.KillDrug on k.KillCullID equals kd.KillCullID
                    join c in Context.Company on k.CompanyID equals c.CompanyID
                    where k.KillCullID ==code
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
            if (query != null)
            {
                result = JsonConvert.SerializeObject(query);
            }

            return result;
        }

        /// <summary>
        /// 养殖场
        /// </summary>
        /// <param name="code"></param>
        /// <param name="epc"></param>
        /// <param name="orcode"></param>
        /// <returns></returns>
        public string GetCultivation(int code, string epc, string orcode)
        {
            string result = string.Empty;

            var query = (from cb in Context.CultivationBase
                join b in Context.BreedBase on cb.BreedID equals b.BreedID
                join bd in Context.BreedDrug on cb.CultivationID equals bd.CultivationID
                join bh in Context.BreedHome on cb.AreaID equals bh.AreaID
                join bm in Context.BreedMaterial on cb.CultivationID equals bm.CultivationID
                join bheal in Context.BreedHealth on cb.CultivationID equals bheal.CultivationID
                join lb in Context.LandBase on b.LandID equals lb.LandID
                where cb.CultivationID==code
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

            if (query!=null)
            {
                result = JsonConvert.SerializeObject(query);
            }
            return result;
        }

        /// <summary>
        /// 个体
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public string GetTraceUint(int code)
        {
            string result = string.Empty;

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

            if (query != null)
            {
                result = JsonConvert.SerializeObject(query);
            }

            return result;
        }
    }
}

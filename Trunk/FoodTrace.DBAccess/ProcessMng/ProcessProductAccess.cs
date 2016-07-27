using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.DtoModel;

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
                    list.Add(warehouse);
                }

                //销售公司
                var baseSale = GetSaleBaseByEpc(epc, orCode);
                if (baseSale != null)
                {
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
                       list.Add(saleCompany);
                    }
                }
               

                //加工厂
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
                    list.Add(procFactory);

                }

                //屠宰场
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
                    list.Add(killFatory);
                }

                //养殖场
                var cultivate = (from c in Context.CultivationBase
                    join b in Context.BreedBase on c.BreedID equals b.BreedID
                    where c.CultivationEpc == productBase.ProcessEPC
                    select new ProductTraceDto()
                    {
                        Code = b.BreedID,
                        Name = b.BreedName,
                        Type = 2,
                        Image = ""
                    }).FirstOrDefault();

                if (cultivate != null)
                {
                    list.Add(cultivate);
                }

                //个体
                var unit = (from c in Context.CultivationBase
                    where c.CultivationEpc == productBase.ProcessEPC
                    select new ProductTraceDto()
                    {
                        Code = c.CultivationID,
                        Name = c.VarietyName,
                        Type = 1,
                        Image = ""
                    }).FirstOrDefault();

                if (unit != null)
                {
                    list.Add(unit);
                }

            }
            return list;
        }

      
    }
}

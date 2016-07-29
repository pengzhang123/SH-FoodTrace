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
    public class ShadowBaseAccess : BaseAccess, IShadowBaseAccess
    {
        public int GetEntityCount()
        {
            return base.Context.ShadowBase.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.ShadowBase.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.ShadowEPC.Contains(code))).Count();
        }

        public List<ShadowBaseModel> GetAllEntities()
        {
            return base.Context.ShadowBase.ToList();
        }

        public ShadowBaseModel GetEntityById(int id)
        {
            return base.Context.ShadowBase.FirstOrDefault(m => m.ShadowID == id);
        }

        public MessageModel InsertSingleEntity(ShadowBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.ShadowBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public ShadowBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.ShadowBase.FirstOrDefault(m => m.ShadowID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(ShadowBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.ShadowBase.FirstOrDefault(m => m.ShadowID == model.ShadowID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.CompanyID = model.CompanyID;
                data.ProductID = model.ProductID;
                data.ProductName = model.ProductName;
                data.ProductTypeID = model.ProductTypeID;
                data.Price = model.Price;
                data.ProductCode = model.ProductCode;
                data.ShadowEPC = model.ShadowEPC;
                data.ORCode = model.ORCode;
                data.ChipCode = model.ChipCode;
                data.ProcessBatch = model.ProcessBatch;
                data.Method = model.Method;
                data.ProcessTime = model.ProcessTime;
                data.Temp = model.Temp;
                data.Dry = model.Dry;
                data.DryTime = model.DryTime;
                data.RawBatch = model.RawBatch;
                data.Flow = model.Flow;
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
                if (context.ShadowProcess.Any(m => m.ShadowID == id)) return "该地块信息存在关联数据，不能被删除！";

                var data = Context.ShadowBase.FirstOrDefault(m => m.ShadowID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<ShadowBaseModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<ShadowBaseModel> GetPagerShadowBaseByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.ShadowBase.Where(m => (string.IsNullOrEmpty(code) || m.ShadowEPC.Contains(code)))
                     .OrderBy(m => m.ShadowID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public ShadowBaseModel GetShawInfoByEPCOrORCode(string Epc, string OrCode)
        {
            return base.Context.ShadowBase.FirstOrDefault(m => (string.IsNullOrEmpty(Epc) || m.ChipCode == Epc)&& (string.IsNullOrEmpty(OrCode) || m.ORCode == OrCode));
        }

        public ShadowBaseModel GetShawInfoByChipCode(string chipCode)
        {
            return base.Context.ShadowBase.FirstOrDefault(m => m.ChipCode == chipCode);
        }

        /// <summary>
        /// 皮影的基本信息
        /// </summary>
        /// <param name="epc"></param>
        /// <param name="orCode"></param>
        /// <returns></returns>
        public ShadowBaseDto GetShadowByEpcOrCode(string epc, string orCode)
        {
            var query = Context.ShadowBase.AsQueryable();
            if (!string.IsNullOrEmpty(epc))
            {
                query = query.Where(s => s.ChipCode == epc);
            }
            if (!string.IsNullOrEmpty(orCode))
            {
                query = query.Where(s => s.ORCode == orCode);
            }

            var model = query.FirstOrDefault();
            if (model == null)
            {
                return null;
            }

            var shadow = new ShadowBaseDto()
            {
                Name = model.ProductName,
                Price = model.Price,
                Method = model.Method,
                Temp = model.Temp,
                Dry = model.Dry,
                ProcessBatch = model.ProcessBatch
            };
            var company = Context.Company.Find(model.CompanyID);
            if (company != null)
            {
                shadow.CompanyName = company.CompanyName;
            }

            var productbase = (from p in Context.ProductBase
                join pt in Context.ProductType on p.ProductTypeID equals pt.ProductTypeID
                where p.ProductID == model.ProductID
                select new ProductInfoDto()
                {
                    Price = p.Price,
                    Weight = p.Weight,
                    TypeName = pt.ProductTypeEN
                }).FirstOrDefault();

            if (productbase != null)
            {
                shadow.Price = productbase.Price;
                shadow.Weight = productbase.Weight;
                shadow.TypeName = productbase.TypeName;
            }

            return shadow;
        }
    }
}

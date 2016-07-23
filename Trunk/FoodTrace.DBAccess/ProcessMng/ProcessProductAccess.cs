using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}

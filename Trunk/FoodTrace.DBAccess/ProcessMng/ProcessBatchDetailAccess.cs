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
    public class ProcessBatchDetailAccess : BaseAccess, IProcessBatchDetailAccess
    {
        public int GetEntityCount()
        {
            return base.Context.ProcessBatchDetail.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.ProcessBatchDetail.Where(m => m.ProcessBatch.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.ProcessEPC.Contains(code))).Count();
        }

        public List<ProcessBatchDetailModel> GetAllEntities()
        {
            return base.Context.ProcessBatchDetail.ToList();
        }

        public ProcessBatchDetailModel GetEntityById(int id)
        {
            return base.Context.ProcessBatchDetail.FirstOrDefault(m => m.DetailID == id);
        }

        public MessageModel InsertSingleEntity(ProcessBatchDetailModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.ProcessBatchDetail.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public ProcessBatchDetailModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.ProcessBatchDetail.FirstOrDefault(m => m.DetailID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(ProcessBatchDetailModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.ProcessBatchDetail.FirstOrDefault(m => m.DetailID == model.DetailID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.PApplyID = model.PApplyID;
                data.RecvType = model.RecvType;
                data.ProcessEPC = model.ProcessEPC;
                data.ProductName = model.ProductName;
                data.Weight = model.Weight;
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
                if (context.ProcessProduct.Any(m => m.DetailID == id)) return "该加工明细信息存在关联数据，不能被删除！";

                var data = Context.ProcessBatchDetail.FirstOrDefault(m => m.DetailID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<ProcessBatchDetailModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<ProcessBatchDetailModel> GetPagerProcessBatchDetailByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.ProcessBatchDetail.Where(m => m.ProcessBatch.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.ProcessEPC.Contains(code)))
                     .OrderBy(m => m.DetailID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

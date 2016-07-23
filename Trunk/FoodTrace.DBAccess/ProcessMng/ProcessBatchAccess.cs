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
    public class ProcessBatchAccess : BaseAccess, IProcessBatchAccess
    {
        public int GetEntityCount()
        {
            return base.Context.ProcessBatch.Count();
        }

        public int GetEntityCount(int companyID, string batchNo)
        {
            return base.Context.ProcessBatch.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(batchNo) || m.BatchNo.Contains(batchNo))).Count();
        }

        public List<ProcessBatchModel> GetAllEntities()
        {
            return base.Context.ProcessBatch.ToList();
        }

        public ProcessBatchModel GetEntityById(int id)
        {
            return base.Context.ProcessBatch.FirstOrDefault(m => m.PApplyID == id);
        }

        public MessageModel InsertSingleEntity(ProcessBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.ProcessBatch.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public ProcessBatchModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.ProcessBatch.FirstOrDefault(m => m.PApplyID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(ProcessBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.ProcessBatch.FirstOrDefault(m => m.PApplyID == model.PApplyID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.CompanyID = model.CompanyID;
                data.BatchNo = model.BatchNo;
                data.RecvicePeople = model.RecvicePeople;
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
                if (context.ProcessBatchDetail.Any(m => m.PApplyID == id)) return "该待加工订单信息存在关联数据，不能被删除！";

                var data = Context.ProcessBatch.FirstOrDefault(m => m.PApplyID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<ProcessBatchModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<ProcessBatchModel> GetPagerProcessBatchByConditions(int companyID, string batchNo, int pageIndex, int pageSize)
        {
            return base.Context.ProcessBatch.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(batchNo) || m.BatchNo.Contains(batchNo)))
                     .OrderBy(m => m.PApplyID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

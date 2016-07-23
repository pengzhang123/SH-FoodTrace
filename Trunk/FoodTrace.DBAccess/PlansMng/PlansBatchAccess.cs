using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    /// <summary>
    /// 批次产品种植计划
    /// </summary>
    public class PlansBatchAccess : BaseAccess, IPlansBatchAccess
    {
        public int GetEntityCount()
        {
            return base.Context.PlansBatch.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.PlansBatch.Where(m => m.LandBlock.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.BatchCode.Contains(code))).Count();
        }

        public List<PlansBatchModel> GetAllEntities()
        {
            return base.Context.PlansBatch.ToList();
        }

        public PlansBatchModel GetEntityById(int id)
        {
            return base.Context.PlansBatch.FirstOrDefault(m => m.BatchID == id);
        }

        public MessageModel InsertSingleEntity(PlansBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.PlansBatch.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public PlansBatchModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.PlansBatch.FirstOrDefault(m => m.BatchID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(PlansBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.PlansBatch.FirstOrDefault(m => m.BatchID == model.BatchID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.BlockID = model.BlockID;
                data.SeedID = model.SeedID;
                data.BatchNO = model.BatchNO;
                data.BatchCode = model.BatchCode;
                data.PlansTime = model.PlansTime;
                data.PlansYear = model.PlansYear;
                data.HarvestTime = model.HarvestTime;
                data.PlansArea = model.PlansArea;
                data.ChargePerson = model.ChargePerson;
                data.HarvestCount = model.HarvestCount;
                data.RealCount = model.RealCount;
                data.People = model.People;
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
                if (context.PlansDrug.Any(m => m.BatchID == id) || context.PlansFert.Any(m => m.BatchID == id)) return "该种植计划信息存在关联数据，不能被删除！";

                var data = Context.PlansBatch.FirstOrDefault(m => m.BatchID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<PlansBatchModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<PlansBatchModel> GetPagerPlansBatchByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.PlansBatch.Where(m => m.LandBlock.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.BatchCode.Contains(code)))
                    .OrderBy(m => m.BatchID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public PlansBatchModel GetPlansBatchByEPCOrORCode(string Epc, string OrCode)
        {
            return Context.PlansBatch.FirstOrDefault(m => string.IsNullOrEmpty(Epc) || m.BatchCode == Epc);
        }
    }
}

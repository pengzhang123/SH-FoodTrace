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
    /// 种植用药情况
    /// </summary>
    public class PlansDrugAccess : BaseAccess, IPlansDrugAccess
    {
        public int GetEntityCount()
        {
            return base.Context.PlansDrug.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.PlansDrug.Where(m => m.PlansBatch.LandBlock.LandBase.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.PlansCode.Contains(code))).Count();
        }

        public List<PlansDrugModel> GetAllEntities()
        {
            return base.Context.PlansDrug.ToList();
        }

        public PlansDrugModel GetEntityById(int id)
        {
            return base.Context.PlansDrug.FirstOrDefault(m => m.DrugID == id);
        }

        public MessageModel InsertSingleEntity(PlansDrugModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.PlansDrug.Add(model);
                context.SaveChanges();

                int id = model.DrugID;
                //foreach (var item in model.PlansDrugPic)
                //    context.PlansDrugPic.Add(item);
                //foreach (var item in model.PlansDrugVideo)
                //    context.PlansDrugVideo.Add(item);
                //context.SaveChanges();

                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public PlansDrugModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.PlansDrug.FirstOrDefault(m => m.DrugID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(PlansDrugModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.PlansDrug.FirstOrDefault(m => m.DrugID == model.DrugID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.BatchID = model.BatchID;
                data.People = model.People;
                data.Object = model.Object;
                data.DrugName = model.DrugName;
                data.DrugTime = model.DrugTime;
                data.Problem = model.Problem;
                data.Method = model.Method;
                data.UANum = model.UANum;
                data.Dilution = model.Dilution;
                data.Weather = model.Weather;
                data.Pic = model.Pic;
                data.PlansCode = model.PlansCode;
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
                var data = Context.PlansDrug.FirstOrDefault(m => m.DrugID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<PlansDrugModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<PlansDrugModel> GetPagerPlansDrugByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.PlansDrug.Where(m => m.PlansBatch.LandBlock.LandBase.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.PlansCode.Contains(code)))
                    .OrderBy(m=>m.DrugID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

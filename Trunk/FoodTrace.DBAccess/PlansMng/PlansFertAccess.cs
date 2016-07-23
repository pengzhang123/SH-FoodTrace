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
    /// 种植施肥情况
    /// </summary>
    public class PlansFertAccess : BaseAccess, IPlansFertAccess
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

        public List<PlansFertModel> GetAllEntities()
        {
            return base.Context.PlansFert.ToList();
        }

        public PlansFertModel GetEntityById(int id)
        {
            return base.Context.PlansFert.FirstOrDefault(m => m.FertID == id);
        }


        public MessageModel InsertSingleEntity(PlansFertModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.PlansFert.Add(model);
                context.SaveChanges();

                int id = model.FertID;
                //foreach (var item in model.PlansFertPic)
                //    context.PlansFertPic.Add(item);
                //foreach (var item in model.PlansFertVideo)
                //    context.PlansFertVideo.Add(item);
                context.SaveChanges();

                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public PlansFertModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.PlansFert.FirstOrDefault(m => m.FertID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(PlansFertModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.PlansFert.FirstOrDefault(m => m.FertID == model.FertID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.BatchID = model.BatchID;
                data.FertCode = model.FertCode;
                data.FertName = model.FertName;
                data.FertPeople = model.FertPeople;
                data.FertTime = model.FertTime;
                data.FertType = model.FertType;
                data.FertMethod = model.FertMethod;
                data.UANum = model.UANum;
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
                var data = Context.PlansFert.FirstOrDefault(m => m.FertID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<PlansFertModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<PlansFertModel> GetPagerPlansFertByConditions(int companyID,string code, int pageIndex, int pageSize)
        {
            return base.Context.PlansFert.Where(m => m.PlansBatch.LandBlock.LandBase.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.PlansCode.Contains(code)))
                    .OrderBy(m => m.FertID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

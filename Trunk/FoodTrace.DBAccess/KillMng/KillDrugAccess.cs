using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class KillDrugAccess : BaseAccess, IKillDrugAccess
    {
        public int GetEntityCount()
        {
            return base.Context.KillDrug.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.KillDrug.Where(m => m.KillCull.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.KillEpc.Contains(code))).Count();
        }

        public List<KillDrugModel> GetAllEntities()
        {
            return base.Context.KillDrug.ToList();
        }

        public KillDrugModel GetEntityById(int id)
        {
            return base.Context.KillDrug.FirstOrDefault(m => m.DrugID == id);
        }

        public MessageModel InsertSingleEntity(KillDrugModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.KillDrug.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public KillDrugModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.KillDrug.FirstOrDefault(m => m.DrugID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(KillDrugModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.KillDrug.FirstOrDefault(m => m.DrugID == model.DrugID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.KillCullID = model.KillCullID;
                data.KillEpc = model.KillEpc;
                data.People = model.People;
                data.DrugTime = model.DrugTime;
                data.IsNormal = model.IsNormal;
                data.Pic = model.Pic;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
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
                //if (context.KillDrug.Any(m => m.DrugID == id)) return "该屠宰转换信息存在关联数据，不能被删除！";

                var data = Context.KillDrug.FirstOrDefault(m => m.DrugID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<KillDrugModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<KillDrugModel> GetPagerKillDrugByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.KillDrug.Where(m => m.KillCull.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.KillEpc.Contains(code)))
                     .OrderBy(m => m.DrugID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedDrugAccess : BaseAccess, IBreedDrugAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedDrug.FirstOrDefault(m => m.DrugID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedDrugModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedDrugModel> GetAllEntities()
        {
            return base.Context.BreedDrug.ToList();
        }

        public BreedDrugModel GetEntityById(int id)
        {
            return base.Context.BreedDrug.FirstOrDefault(m => m.DrugID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedDrug.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedDrug.Where(m => m.CultivationBase.BreedBase.LandBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.DrugName == name)).Count();
        }

        public BreedDrugModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedDrug.FirstOrDefault(m => m.DrugID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedDrugModel> GetPagerBreedDrugByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedDrug.Where(m => m.CultivationBase.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.DrugName == name))
                                                    .OrderBy(m => m.DrugID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedDrugModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.BreedDrug.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedDrugModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.BreedDrug.FirstOrDefault(m => m.DrugID == model.DrugID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.DrugID = model.DrugID;
                data.CultivationID = model.CultivationID;
                data.CultivationEpc = model.CultivationEpc;
                data.People = model.People;
                data.Object = model.Object;
                data.DrugName = model.DrugName;
                data.DrugTime = model.DrugTime;
                data.Problem = model.Problem;
                data.Method = model.Method;
                data.DrugCon = model.DrugCon;
                data.Dilution = model.Dilution;
                data.Weather = model.Weather;
                data.Pic = model.Pic;
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
    }
}

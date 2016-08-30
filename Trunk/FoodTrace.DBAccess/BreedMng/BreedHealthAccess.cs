using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedHealthAccess : BaseAccess, IBreedHealthAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHealth.FirstOrDefault(m => m.HealthID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedHealthModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedHealthModel> GetAllEntities()
        {
            return base.Context.BreedHealth.ToList();
        }

        public BreedHealthModel GetEntityById(int id)
        {
            return base.Context.BreedHealth.FirstOrDefault(m => m.HealthID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedHealth.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedHealth.Where(m => m.CultivationBase.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.HealthState == name)).Count();
        }

        public BreedHealthModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedHealth.FirstOrDefault(m => m.HealthID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedHealthModel> GetPagerBreedHealthByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedHealth.Where(m => m.CultivationBase.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.HealthState == name))
                                                    .OrderBy(m => m.HealthID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedHealthModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.BreedHealth.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedHealthModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHealth.FirstOrDefault(m => m.HealthID == model.HealthID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.HealthID = model.HealthID;
                data.CultivationID = model.CultivationID;
                data.CultivationEpc = model.CultivationEpc;
                data.People = model.People;
                data.CheckTime = model.CheckTime;
                data.Weather = model.Weather;
                data.HealthState = model.HealthState;
                data.Pic = model.Pic;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.ModifyID = UserManagement.CurrentUser.UserID;
                data.ModifyName = UserManagement.CurrentUser.UserName;
                data.ModifyTime = DateTime.Now;
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }
    }
}

using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedHomeAccess : BaseAccess, IBreedHomeAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHome.FirstOrDefault(m => m.HomeID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedHomeModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedHomeModel> GetAllEntities()
        {
            return base.Context.BreedHome.ToList();
        }

        public BreedHomeModel GetEntityById(int id)
        {
            return base.Context.BreedHome.FirstOrDefault(m => m.HomeID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedHome.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedHome.Where(m => m.BreedArea.BreedBase.LandBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.HomeName == name)).Count();
        }

        public BreedHomeModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedHome.FirstOrDefault(m => m.HomeID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedHomeModel> GetPagerBreedHomeByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedHome.Where(m => m.BreedArea.BreedBase.LandBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.HomeName == name))
                                                  .OrderBy(m => m.HomeID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedHomeModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedHome.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedHomeModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHome.FirstOrDefault(m => m.HomeID == model.HomeID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.HomeID = model.HomeID;
                data.AreaID = model.AreaID;
                data.HomeName = model.HomeName;
                data.Who = model.Who;
                data.People = model.People;
                data.HealthStatus = model.HealthStatus;
                data.CreateTime = model.CreateTime;
                data.Responsibility = model.Responsibility;
                data.Variety = model.Variety;
                data.Area = model.Area;
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

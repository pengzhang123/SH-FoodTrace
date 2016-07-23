using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedAreaAccess : BaseAccess, IBreedAreaAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedArea.FirstOrDefault(m => m.AreaID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedAreaModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedAreaModel> GetAllEntities()
        {
           return base.Context.BreedArea.ToList();
        }

        public BreedAreaModel GetEntityById(int id)
        {
            return base.Context.BreedArea.FirstOrDefault(m => m.AreaID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedArea.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedArea.Where(m => m.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.AreaName == name)).Count();
        }

        public BreedAreaModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedArea.FirstOrDefault(m => m.AreaID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedAreaModel> GetPagerBreedAreaByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedArea.Where(m => m.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.AreaName == name))
                                                    .OrderBy(m => m.AreaID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedAreaModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedArea.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedAreaModel model)
        {
            Func<IEntityContext, string> operation = (context=>
            {
                var data = context.BreedArea.FirstOrDefault(m => m.AreaID == model.AreaID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.AreaID = model.AreaID;
                data.Area = model.Area;
                data.AreaName = model.AreaName;
                data.BreedID = model.BreedID;
                data.Who = model.Who;
                data.Variety = model.Variety;
                data.People = model.People;
                data.CreateTime = model.CreateTime;
                data.Responsibility = model.Responsibility;
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

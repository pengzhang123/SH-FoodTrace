using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedBaseAccess : BaseAccess, IBreedBaseAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedBase.FirstOrDefault(m => m.BreedID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedBaseModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedBaseModel> GetAllEntities()
        {
            return base.Context.BreedBase.ToList();
        }

        public BreedBaseModel GetEntityById(int id)
        {
            return base.Context.BreedBase.FirstOrDefault(m => m.BreedID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedBase.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedBase.Where(m => m.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.BreedName == name)).Count();
        }

        public BreedBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedBase.FirstOrDefault(m => m.BreedID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedBaseModel> GetPagerBreedBaseByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedBase.Where(m => m.LandBase.CompanyID == companyID
                                                    &&(string.IsNullOrEmpty(name)||m.BreedName==name))
                                                    .OrderBy(m => m.BreedID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedBaseModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedBaseModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedBase.FirstOrDefault(m => m.BreedID == model.BreedID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.BreedID = model.BreedID;
                data.LandID = model.LandID;
                data.BreedName = model.BreedName;
                data.BreedID = model.BreedID;
                data.BreedCode = model.BreedCode;
                data.BreedArea = model.BreedArea;
                data.BreedType = model.BreedType;
                data.Lon = model.Lon;
                data.Lat = model.Lat;
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

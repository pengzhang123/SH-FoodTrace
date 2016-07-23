using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedMaterialAccess : BaseAccess, IBreedMaterialAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedMaterial.FirstOrDefault(m => m.MaterialID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedMaterialModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedMaterialModel> GetAllEntities()
        {
            return base.Context.BreedMaterial.ToList();
        }

        public BreedMaterialModel GetEntityById(int id)
        {
            return base.Context.BreedMaterial.FirstOrDefault(m => m.MaterialID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedMaterial.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedMaterial.Where(m => m.CultivationBase.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.MaterialName == name)).Count();
        }

        public BreedMaterialModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedMaterial.FirstOrDefault(m => m.MaterialID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedMaterialModel> GetPagerBreedMaterialByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedMaterial.Where(m => m.CultivationBase.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.MaterialName == name))
                                                    .OrderBy(m => m.MaterialID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedMaterialModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedMaterial.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedMaterialModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedMaterial.FirstOrDefault(m => m.MaterialID == model.MaterialID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.MaterialID = model.MaterialID;
                data.CultivationID = model.CultivationID;
                data.CultivationEpc = model.CultivationEpc;
                data.MaterialTime = model.MaterialTime;
                data.MaterialType = model.MaterialType;
                data.MaterialName = model.MaterialName;
                data.Method = model.Method;
                data.MaterialCot = model.MaterialCot;
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
            });
            return base.DbOperation(operation);
        }
    }
}

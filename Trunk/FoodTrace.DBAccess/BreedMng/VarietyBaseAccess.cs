using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class VarietyBaseAccess : BaseAccess, IVarietyBaseAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.VarietyBase.FirstOrDefault(m => m.VarietyID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<VarietyBaseModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<VarietyBaseModel> GetAllEntities()
        {
            return base.Context.VarietyBase.ToList();
        }

        public VarietyBaseModel GetEntityById(int id)
        {
            return base.Context.VarietyBase.FirstOrDefault(m => m.VarietyID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.VarietyBase.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.VarietyBase.Where(m=>string.IsNullOrEmpty(name)||m.VarietyName==name).Count();
        }

        public VarietyBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.VarietyBase.FirstOrDefault(m => m.VarietyID == id && m.ModifyTime == modifyTime);
        }

        public List<VarietyBaseModel> GetPagerVarietyBaseByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.VarietyBase.Where(m => string.IsNullOrEmpty(name) || m.VarietyName == name)
                .OrderBy(m => m.VarietyID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(VarietyBaseModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.VarietyBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(VarietyBaseModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.VarietyBase.FirstOrDefault(m => m.VarietyID == model.VarietyID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.VarietyID = model.VarietyID;
                data.DistType = model.DistType;
                data.VarietyType = model.VarietyType;
                data.VarietyCode = model.VarietyCode;
                data.VarietyName = model.VarietyName;
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

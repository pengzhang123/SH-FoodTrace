using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedLogAccess : BaseAccess, IBreedLogAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedLog.FirstOrDefault(m => m.LogID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedLogModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedLogModel> GetAllEntities()
        {
            return base.Context.BreedLog.ToList();
        }

        public BreedLogModel GetEntityById(int id)
        {
            return base.Context.BreedLog.FirstOrDefault(m => m.LogID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedLog.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            throw new NotImplementedException();
        }

        public BreedLogModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedLog.FirstOrDefault(m => m.LogID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedLogModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public MessageModel InsertSingleEntity(BreedLogModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedLog.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedLogModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedLog.FirstOrDefault(m => m.BreedID == model.BreedID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.LogID = model.LogID;
                data.CultivationID = model.CultivationID;
                data.BreedID = model.BreedID;
                data.AreaID = model.AreaID;
                data.HomeID = model.HomeID;
                data.CultivationEpc = model.CultivationEpc;
                data.BatchCode = model.BatchCode;
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

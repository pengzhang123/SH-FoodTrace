using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedBatchAccess : BaseAccess, IBreedBatchAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedBatch.FirstOrDefault(m => m.BreedBatchID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedBatchModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedBatchModel> GetAllEntities()
        {
            return base.Context.BreedBatch.ToList();
        }

        public BreedBatchModel GetEntityById(int id)
        {
            return base.Context.BreedBatch.FirstOrDefault(m => m.BreedBatchID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedBatch.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedBatch.Where(m => m.BreedBase.LandBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.BatchNO == name)).Count();
        }

        public BreedBatchModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedBatch.FirstOrDefault(m => m.BreedBatchID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedBatchModel> GetPagerBreedBatchByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedBatch.Where(m => m.BreedBase.LandBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.BatchNO == name))
                                                    .OrderBy(m => m.BreedID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.BreedBatch.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.BreedBatch.FirstOrDefault(m => m.BreedBatchID == model.BreedBatchID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.BreedBatchID = model.BreedBatchID;
                data.BreedID = model.BreedID;
                data.BatchNO = model.BatchNO;
                data.RecvicePeople = model.RecvicePeople;
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

using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedBatchDetailAccess : BaseAccess, IBreedBatchDetailAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedBatchDetail.FirstOrDefault(m => m.DetailID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedBatchDetailModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedBatchDetailModel> GetAllEntities()
        {
            return base.Context.BreedBatchDetail.ToList();
        }

        public BreedBatchDetailModel GetEntityById(int id)
        {
            return base.Context.BreedBatchDetail.FirstOrDefault(m => m.DetailID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedBatchDetail.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedBatchDetail.Where(m => m.BreedBatch.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.CultivationEpc == name)).Count();
        }

        public BreedBatchDetailModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedBatchDetail.FirstOrDefault(m => m.DetailID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedBatchDetailModel> GetPagerBreedBatchDetailByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedBatchDetail.Where(m => m.BreedBatch.BreedBase.LandBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.CultivationEpc == name))
                                                   .OrderBy(m => m.DetailID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedBatchDetailModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.BreedBatchDetail.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedBatchDetailModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedBatchDetail.FirstOrDefault(m => m.DetailID == model.DetailID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.DetailID = model.DetailID;
                data.BreedBatchID = model.BreedBatchID;
                data.CultivationID = model.CultivationID;
                data.BreedID = model.BreedID;
                data.AreaID = model.AreaID;
                data.HomeID = model.HomeID;
                data.CultivationEpc = model.CultivationEpc;
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

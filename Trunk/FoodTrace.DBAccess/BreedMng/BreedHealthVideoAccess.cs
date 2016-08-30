using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedHealthVideoAccess : BaseAccess, IBreedHealthVideoAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHealthVideo.FirstOrDefault(m => m.VideoID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedHealthVideoModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedHealthVideoModel> GetAllEntities()
        {
            return base.Context.BreedHealthVideo.ToList();
        }

        public BreedHealthVideoModel GetEntityById(int id)
        {
            return base.Context.BreedHealthVideo.FirstOrDefault(m => m.VideoID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedHealthVideo.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            throw new NotImplementedException();
        }

        public BreedHealthVideoModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedHealthVideo.FirstOrDefault(m => m.VideoID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedHealthVideoModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public MessageModel InsertSingleEntity(BreedHealthVideoModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.BreedHealthVideo.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedHealthVideoModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHealthVideo.FirstOrDefault(m => m.VideoID == model.VideoID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.VideoID = model.VideoID;
                data.HealthID = model.HealthID;
                data.Video = model.Video;
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

using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedMaterialVideoAccess : BaseAccess, IBreedMaterialVideoAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedMaterialVideo.FirstOrDefault(m => m.VideoID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedMaterialVideoModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedMaterialVideoModel> GetAllEntities()
        {
            return base.Context.BreedMaterialVideo.ToList();
        }

        public BreedMaterialVideoModel GetEntityById(int id)
        {
            return base.Context.BreedMaterialVideo.FirstOrDefault(m => m.VideoID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedMaterialVideo.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            throw new NotImplementedException();
        }

        public BreedMaterialVideoModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedMaterialVideo.FirstOrDefault(m => m.VideoID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedMaterialVideoModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public MessageModel InsertSingleEntity(BreedMaterialVideoModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.BreedMaterialVideo.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedMaterialVideoModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedMaterialVideo.FirstOrDefault(m => m.VideoID == model.VideoID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.VideoID = model.VideoID;
                data.MaterialID = model.MaterialID;
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

using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedHealthPicAccess : BaseAccess, IBreedHealthPicAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHealthPic.FirstOrDefault(m => m.PicID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedHealthPicModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedHealthPicModel> GetAllEntities()
        {
            return base.Context.BreedHealthPic.ToList();
        }

        public BreedHealthPicModel GetEntityById(int id)
        {
            return base.Context.BreedHealthPic.FirstOrDefault(m => m.PicID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedHealthPic.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            throw new NotImplementedException();
        }

        public BreedHealthPicModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedHealthPic.FirstOrDefault(m => m.PicID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedHealthPicModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public MessageModel InsertSingleEntity(BreedHealthPicModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedHealthPic.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedHealthPicModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHealthPic.FirstOrDefault(m => m.PicID == model.PicID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.PicID = model.PicID;
                data.HealthID = model.HealthID;
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

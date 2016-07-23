using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class BreedMaterialPicAccess : BaseAccess, IBreedMaterialPicAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedMaterialPic.FirstOrDefault(m => m.PicID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedMaterialPicModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedMaterialPicModel> GetAllEntities()
        {
            return base.Context.BreedMaterialPic.ToList();
        }

        public BreedMaterialPicModel GetEntityById(int id)
        {
            return base.Context.BreedMaterialPic.FirstOrDefault(m => m.PicID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedMaterialPic.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            throw new NotImplementedException();
        }

        public BreedMaterialPicModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedMaterialPic.FirstOrDefault(m => m.PicID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedMaterialPicModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public MessageModel InsertSingleEntity(BreedMaterialPicModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedMaterialPic.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedMaterialPicModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedMaterialPic.FirstOrDefault(m => m.PicID == model.PicID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.PicID = model.PicID;
                data.MaterialID = model.MaterialID;
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

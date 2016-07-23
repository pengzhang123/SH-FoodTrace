using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace FoodTrace.DBAccess
{
    /// <summary>
    /// 种植企业基地地块管理
    /// </summary>
    public class LandBlockAccess : BaseAccess, ILandBlockAccess
    {
        public int GetEntityCount()
        {
            return base.Context.LandBlock.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.LandBlock.Where(m => m.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.BlockName.Contains(name))).Count();
        }

        public List<LandBlockModel> GetAllEntities()
        {
            //var test2 = base.Context.LandBlock.ToList();
            //var test1 = base.Context.LandBlock.Include(m => m.LandBase).ToList();

            return base.Context.LandBlock.ToList();
        }

        //public IQueryable<LandBlockModel> GetAllEntities1()
        //{
        //    return base.Context.LandBlock;
        //}

        public LandBlockModel GetEntityById(int id)
        {
            return base.Context.LandBlock.FirstOrDefault(m => m.BlockID == id);
        }

        public MessageModel InsertSingleEntity(LandBlockModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.LandBlock.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public LandBlockModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.LandBlock.FirstOrDefault(m => m.BlockID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(LandBlockModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.LandBlock.FirstOrDefault(m => m.BlockID == model.BlockID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.LandID = model.LandID;
                data.BlockCode = model.BlockCode;
                data.BlockName = model.BlockName;
                data.BlockArea = model.BlockArea;
                data.SoilType = model.SoilType;
                data.SoilName = model.SoilName;
                data.SoilSalinity = model.SoilSalinity;
                data.SoilQuality = model.SoilQuality;
                data.Toc = model.Toc;
                data.LakerSalinity = model.LakerSalinity;
                data.WaterSalinity = model.WaterSalinity;
                data.GroundWater = model.GroundWater;
                data.WaterQuality = model.WaterQuality;
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
            };
            return base.DbOperation(operation);
        }

        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                if (context.PlansBatch.Any(m => m.BlockID == id)) return "该地块信息存在关联数据，不能被删除！";

                var data = Context.LandBlock.FirstOrDefault(m => m.BlockID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<LandBlockModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<LandBlockModel> GetPagerLandBlockByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.LandBlock.Where(m => m.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.BlockName.Contains(name)))
                     .OrderBy(m => m.BlockID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

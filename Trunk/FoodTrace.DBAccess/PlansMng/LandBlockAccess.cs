using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

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
                var data = context.LandBlock.FirstOrDefault(m => m.BlockID == model.BlockID);
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

        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<LandBlockDto> GetLandBlockPaging(int comId, string name, int pIndex, int pSize)
        {
            var query = (from s in Context.LandBlock
                join lb in Context.LandBase on s.LandID equals lb.LandID into lbl
                from lbleft in lbl.DefaultIfEmpty()
                where lbleft.CompanyID == comId

                select new LandBlockDto()
                {
                    BlockID = s.BlockID,
                    BlockName = s.BlockName,
                    BlockArea = s.BlockArea,
                    BlockCode = s.BlockCode,
                    SoilType = s.SoilType,
                    SoilName = s.SoilName,
                    SoilSalinity = s.SoilSalinity,
                    SoilQuality = s.SoilQuality,
                    Lon = s.Lon,
                    Lat = s.Lat,
                    Remark = s.Remark,
                    LandBaseName = lbleft.LandName
                }).AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.BlockName.Contains(name));

            }

            var list = query.OrderBy(s=>s.BlockID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();

            return new GridList<LandBlockDto>(){rows = list,total =query.Count()};
        }

        /// <summary>
        /// 根据id获取地块名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public LandBlockDto GetLandBlockById(int id)
        {
            var query = (from s in Context.LandBlock
                where s.BlockID == id
                select new LandBlockDto()
                {
                    BlockID = s.BlockID,
                    BlockName = s.BlockName,
                    BlockArea = s.BlockArea,
                    BlockCode = s.BlockCode,
                    SoilType = s.SoilType,
                    SoilName = s.SoilName,
                    SoilSalinity = s.SoilSalinity,
                    SoilQuality = s.SoilQuality,
                    Lon = s.Lon,
                    Lat = s.Lat,
                    Remark = s.Remark,
                    Toc=s.Toc,
                    LakerSalinity = s.LakerSalinity,
                    WaterSalinity = s.WaterSalinity,
                    GroundWater = s.GroundWater,
                    WaterQuality = s.WaterQuality,
                    IsLocked = s.IsLocked,
                    IsShow = s.IsShow
                }).FirstOrDefault();

            return query;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                //基地名下包含基地地块信息，则不能被直接删除
                if (ids.Length > 0)
                {
                    var idsArra = ids.Split(',');
                    var landBlock = (from s in context.LandBlock
                                    join id in idsArra on s.BlockID.ToString() equals id
                                    select s).ToList();
                    if (landBlock.Any())
                    {
                        context.BatchDelete(landBlock);
                    }
                }
                return string.Empty;
            };

            return base.DbOperation(operation);
        }
    }
}

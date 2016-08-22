using System.Data.SqlClient;
using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class BreedBaseAccess : BaseAccess, IBreedBaseAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedBase.FirstOrDefault(m => m.BreedID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedBaseModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedBaseModel> GetAllEntities()
        {
            return base.Context.BreedBase.ToList();
        }

        public BreedBaseModel GetEntityById(int id)
        {
            return base.Context.BreedBase.FirstOrDefault(m => m.BreedID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedBase.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedBase.Where(m => m.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.BreedName == name)).Count();
        }

        public BreedBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedBase.FirstOrDefault(m => m.BreedID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedBaseModel> GetPagerBreedBaseByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedBase.Where(m => m.LandBase.CompanyID == companyID
                                                    &&(string.IsNullOrEmpty(name)||m.BreedName==name))
                                                    .OrderBy(m => m.BreedID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedBaseModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedBaseModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedBase.FirstOrDefault(m => m.BreedID == model.BreedID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.BreedID = model.BreedID;
                data.LandID = model.LandID;
                data.BreedName = model.BreedName;
                data.BreedID = model.BreedID;
                data.BreedCode = model.BreedCode;
                data.BreedArea = model.BreedArea;
                data.BreedType = model.BreedType;
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
            });
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<BreedBaseDto> GetBreedBaseListPaging(int comid, int pIndex, int pSize)
        {
            var query = (from s in Context.BreedBase
                join land in Context.LandBase on s.LandID equals land.LandID
                where land.CompanyID==comid
                select new BreedBaseDto()
                {
                    BreedID =s.BreedID,
                    LandID = s.LandID,
                    LandName = land.LandName,
                    BreedName = s.BreedName,
                    BreedArea = s.BreedArea,
                    BreedType = s.BreedType,
                    Lon = s.Lon,
                    Lat = s.Lat,
                    Remark = s.Remark,
                    IsLocked = s.IsLocked,
                    IsShow = s.IsShow
                }).AsQueryable();

            var list = query.OrderBy(s => s.BreedID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();

            return new GridList<BreedBaseDto>(){rows = list,total = query.Count()};
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var idsArray = ids.Split(',');
                var data = context.BreedBase.Where(s => idsArray.Contains(s.BreedID.ToString())).ToList();
                if (data.Any())
                {
                    context.BatchDelete(data);
                }
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedBaseDto GetBreedBaseDtoById(int id)
        {
            var query = (from s in Context.BreedBase
                         where s.BreedID==id
                         select new BreedBaseDto()
                         {
                             BreedID = s.BreedID,
                             LandID = s.LandID,
                             BreedName = s.BreedName,
                             BreedArea = s.BreedArea,
                             BreedType = s.BreedType,
                             Lon = s.Lon,
                             Lat = s.Lat,
                             Remark = s.Remark,
                             IsLocked = s.IsLocked,
                             IsShow = s.IsShow
                         }).FirstOrDefault();

            return query;
        }
    }
}

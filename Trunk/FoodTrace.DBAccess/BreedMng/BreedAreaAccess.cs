using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.BreedMng;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class BreedAreaAccess : BaseAccess, IBreedAreaAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedArea.FirstOrDefault(m => m.AreaID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedAreaModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedAreaModel> GetAllEntities()
        {
           return base.Context.BreedArea.ToList();
        }

        public BreedAreaModel GetEntityById(int id)
        {
            return base.Context.BreedArea.FirstOrDefault(m => m.AreaID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedArea.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedArea.Where(m => m.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.AreaName == name)).Count();
        }

        public BreedAreaModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedArea.FirstOrDefault(m => m.AreaID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedAreaModel> GetPagerBreedAreaByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedArea.Where(m => m.BreedBase.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.AreaName == name))
                                                    .OrderBy(m => m.AreaID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedAreaModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedArea.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedAreaModel model)
        {
            Func<IEntityContext, string> operation = (context=>
            {
                var data = context.BreedArea.FirstOrDefault(m => m.AreaID == model.AreaID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.AreaID = model.AreaID;
                data.Area = model.Area;
                data.AreaName = model.AreaName;
                data.BreedID = model.BreedID;
                data.Who = model.Who;
                data.Variety = model.Variety;
                data.People = model.People;
                data.CreateTime = model.CreateTime;
                data.Responsibility = model.Responsibility;
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
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<BreedAreaDto> GetAreaGridList(int comId, int pIndex, int pSize)
        {
            var query = (from s in Context.BreedArea
                         
                         join breed in Context.BreedBase on s.BreedID equals breed.BreedID
                        join land in Context.LandBase on breed.LandID equals land.LandID
                        where land.CompanyID == comId
                select new BreedAreaDto
                {
                    AreaID = s.AreaID,
                    BreedID = s.BreedID,
                    AreaName = s.AreaName,
                    BreedName = breed.BreedName,
                    Area = s.Area,
                    Who = s.Who,
                    Variety =s.Variety,
                    People = s.People,
                    CreateTime = s.CreateTime,
                    Responsibility = s.Responsibility,
                    Remark = s.Remark,
                    IsLocked = s.IsLocked,
                    IsShow = s.IsShow
                }).AsQueryable();

            var list = query.OrderBy(s => s.AreaID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();

            return new GridList<BreedAreaDto>(){rows = list,total=list.Count()};
        }

        /// <summary>
        /// 根据Id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedAreaDto GetAreaDtoById(int id)
        {
            var query = (from s in Context.BreedArea
                        where s.BreedID==id
                         select new BreedAreaDto
                         {
                             AreaID = s.AreaID,
                             BreedID = s.BreedID,
                             AreaName = s.AreaName,
                             Area = s.Area,
                             Who = s.Who,
                             Variety= s.Variety,
                             People = s.People,
                             CreateTime = s.CreateTime,
                             Responsibility = s.Responsibility,
                             Remark = s.Remark,
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
            Func<IEntityContext, string> operation = (context =>
            {
                var idsArray = ids.Split(',');
                var list = context.BreedArea.Where(s => idsArray.Contains(s.AreaID.ToString())).ToList();

                if (list.Any())
                {
                    context.BatchDelete(list);
                }
                return string.Empty;
            });

            return base.DbOperation(operation); 
        }
    }
}

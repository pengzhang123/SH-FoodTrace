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
    public class BreedHomeAccess : BaseAccess, IBreedHomeAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHome.FirstOrDefault(m => m.HomeID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<BreedHomeModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<BreedHomeModel> GetAllEntities()
        {
            return base.Context.BreedHome.ToList();
        }

        public BreedHomeModel GetEntityById(int id)
        {
            return base.Context.BreedHome.FirstOrDefault(m => m.HomeID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.BreedHome.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.BreedHome.Where(m => m.BreedArea.BreedBase.LandBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.HomeName == name)).Count();
        }

        public BreedHomeModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.BreedHome.FirstOrDefault(m => m.HomeID == id && m.ModifyTime == modifyTime);
        }

        public List<BreedHomeModel> GetPagerBreedHomeByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.BreedHome.Where(m => m.BreedArea.BreedBase.LandBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.HomeName == name))
                                                  .OrderBy(m => m.HomeID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(BreedHomeModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.BreedHome.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(BreedHomeModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.BreedHome.FirstOrDefault(m => m.HomeID == model.HomeID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.HomeID = model.HomeID;
                data.AreaID = model.AreaID;
                data.HomeName = model.HomeName;
                data.Who = model.Who;
                data.People = model.People;
                data.HealthStatus = model.HealthStatus;
                data.CreateTime = model.CreateTime;
                data.Responsibility = model.Responsibility;
                data.Variety = model.Variety;
                data.Area = model.Area;
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
        public GridList<BreedHomeDto> GetBreedHomeGridList(int comId, int pIndex, int pSize)
        {
            var query = (from s in Context.BreedHome
                join area in Context.BreedArea on s.AreaID equals area.AreaID
                join breed in Context.BreedBase on area.BreedID equals breed.BreedID
                join land in Context.LandBase on breed.LandID equals land.LandID
              
                where land.CompanyID == comId
                select new BreedHomeDto()
                {
                    HomeID = s.HomeID,
                    AreaName = area.AreaName,
                    HomeName = s.HomeName,
                    Who = s.Who,
                    People = s.People,
                    HealthStatus = s.HealthStatus,
                    Responsibility = s.Responsibility,
                    VarietyName= s.Variety,
                    Remark = s.Remark,
                    Area=s.Area
                }).AsQueryable();

            var list = query.OrderBy(s => s.HomeID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();


            return new GridList<BreedHomeDto>() { rows = list, total = query.Count() };

        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BreedHomeDto GetBreedHomeDtoById(int id)
        {
            var query=(from s in Context.BreedHome
                       where s.HomeID==id
                        select new BreedHomeDto(){
                    HomeID = s.HomeID,
                    AreaID = s.AreaID,
                    HomeName = s.HomeName,
                    Who = s.Who,
                    People = s.People,
                    HealthStatus = s.HealthStatus,
                    Responsibility = s.Responsibility,
                    Variety=s.Variety,
                    Remark = s.Remark,
                    Area=s.Area,
                    IsShow = s.IsShow,
                    IsLocked = s.IsLocked
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
                var idarrary = ids.Split(',');

                var list = context.BreedHome.Where(s => idarrary.Contains(s.HomeID.ToString())).ToList();
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

using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;

namespace FoodTrace.DBAccess
{
    public class CountryAccess : BaseAccess, ICountryAccess
    {
        public int GetEntityCount()
        {
            return base.Context.Country.Count();
        }

        public int GetEntityCount(int? cityId, string name)
        {
            var city = Context.City.FirstOrDefault(m => !cityId.HasValue || m.CityID == cityId);
            return base.Context.Country.Where(m => (city == null || m.City.CityCode == city.CityCode)
                                                    && (string.IsNullOrEmpty(name) || m.CountryName.Contains(name))).Count();
        }

        public List<CountryModel> GetAllEntities()
        {
            return base.Context.Country.ToList();
        }

        public CountryModel GetEntityById(int id)
        {
            return base.Context.Country.FirstOrDefault(m => m.CountryID == id);
        }

        public MessageModel InsertSingleEntity(CountryModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.Country.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public CountryModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.Country.FirstOrDefault(m => m.CountryID == id /*&& m.ModifyTime == modifyTime*/);
        }

        public MessageModel UpdateSingleEntity(CountryModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.Country.FirstOrDefault(m => m.CountryID == model.CountryID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.CountryCode = model.CountryCode;
                data.CountryName = model.CountryName;
                data.ProvinceId = model.ProvinceId;
                data.CityID = model.CityID;
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.Country.FirstOrDefault(m => m.CountryID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                //if (context.Country.Any(m => m.CountryCode == data.CountryCode)) return "该区县信息存在关联数据，不能被删除！";

                context.DeleteAndSave<CountryModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
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
                var idsArray = ids.Split(',');
                var data = context.Country.Where(s=>idsArray.Contains(s.CountryID.ToString())).ToList();
                if (data.Any())
                {
                    context.BatchDelete(data);
                }
                //if (context.Country.Any(m => m.CountryCode == data.CountryCode)) return "该区县信息存在关联数据，不能被删除！";
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }
        public List<CountryModel> GetPagerCountryByConditions(int? cityId, string name, int pageIndex, int pageSize)
        {
            //var city = Context.City.FirstOrDefault(m => (!cityId.HasValue || m.CityID == cityId));
            return base.Context.Country.Where(m => (cityId == null || m.City.CityID == cityId)
                                                && (string.IsNullOrEmpty(name) || m.CountryName.Contains(name)))
                    .OrderBy(m => m.CountryID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<CountryDto> GetCountryListPaging(int? cityId, string name, int pIndex, int pSize)
         {
             var query = (from s in Context.Country
                 join c in Context.City on s.CityID equals c.CityID into cl
                 from cleft in cl.DefaultIfEmpty()
                 select new CountryDto()
                 {
                     CountryID = s.CountryID,
                     CountryCode = s.CountryCode,
                     CountryName = s.CountryName,
                     CityID = s.CityID,
                     CityName = cleft.CityName
                 }).AsQueryable();

             if (cityId != null && cityId > 0)
             {
                 query = query.Where(s => s.CityID == cityId);
             }
             if (!string.IsNullOrEmpty(name))
             {
                 query = query.Where(s => s.CountryName.Contains(name));
             }

             var list = query.OrderBy(s => s.CountryID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();

             return new GridList<CountryDto>(){rows=list,total=query.Count()};
         }
    }
}

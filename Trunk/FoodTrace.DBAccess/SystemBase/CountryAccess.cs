using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<CountryModel> GetPagerCountryByConditions(int? cityId, string name, int pageIndex, int pageSize)
        {
            //var city = Context.City.FirstOrDefault(m => (!cityId.HasValue || m.CityID == cityId));
            return base.Context.Country.Where(m => (cityId == null || m.City.CityID == cityId)
                                                && (string.IsNullOrEmpty(name) || m.CountryName.Contains(name)))
                    .OrderBy(m => m.CountryID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

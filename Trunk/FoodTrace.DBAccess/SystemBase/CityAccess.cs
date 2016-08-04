﻿using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.DBAccess
{
    public class CityAccess : BaseAccess, ICityAccess
    {
        public int GetEntityCount()
        {
            return base.Context.City.Count();
        }

        public int GetEntityCount(int? provinceId, string name)
        {
            var province = Context.Province.FirstOrDefault(m => !provinceId.HasValue || m.ProvinceID == provinceId);
            return base.Context.City.Where(m => (province == null || m.Province.ProvinceCode == province.ProvinceCode)
                                                    && (string.IsNullOrEmpty(name) || m.CityName.Contains(name))).Count();
        }

        public List<CityModel> GetAllEntities()
        {
            return base.Context.City.ToList();
        }

        public CityModel GetEntityById(int id)
        {
            return base.Context.City.FirstOrDefault(m => m.CityID == id);
        }

        public MessageModel InsertSingleEntity(CityModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.City.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public CityModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.City.FirstOrDefault(m => m.CityID == id /*&& m.ModifyTime == modifyTime*/);
        }

        public MessageModel UpdateSingleEntity(CityModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.City.FirstOrDefault(m => m.CityID == model.CityID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.CityCode = model.CityCode;
                data.CityName = model.CityName;
                data.CityAreaCode = model.CityAreaCode;
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.City.FirstOrDefault(m => m.CityID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                if (context.Country.Any(m => m.City.CityCode == data.CityCode)) return "该城市信息存在关联数据，不能被删除！";

                context.DeleteAndSave<CityModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteCityByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var city = context.City.Where(s => ids.Contains(s.CityID.ToString())).ToList();
                if (city.Any())
                {
                    context.BatchDelete(city);
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }
        public List<CityModel> GetPagerCityByConditions(int? provinceId, string name, int pageIndex, int pageSize)
        {
            //var province = Context.Province.FirstOrDefault(m => (!provinceId.HasValue || m.ProvinceID == provinceId));
            return base.Context.City.Where(m => (!provinceId.HasValue || m.ProvinceID == provinceId)
                                                /*&& (string.IsNullOrEmpty(name) || m.CityName.Contains(name))*/)
                    .OrderBy(m => m.CityID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

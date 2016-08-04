using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class ProductSpecAccess : BaseAccess, IProductSpecAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.ProductSpec.FirstOrDefault(m => m.SPCID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<ProductSpecModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<ProductSpecModel> GetAllEntities()
        {
            return base.Context.ProductSpec.ToList();
        }

        public ProductSpecModel GetEntityById(int id)
        {
            return base.Context.ProductSpec.FirstOrDefault(m => m.SPCID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.ProductSpec.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.ProductSpec.Where(m => string.IsNullOrEmpty(name) || m.SpecName == name).Count();
        }

        public ProductSpecModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.ProductSpec.FirstOrDefault(m => m.SPCID == id && m.ModifyTime == modifyTime);
        }

        public List<ProductSpecModel> GetPagerProductSpecByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.ProductSpec.Where(m => string.IsNullOrEmpty(name) || m.SpecName == name)
                                                    .OrderBy(m => m.SPCID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(ProductSpecModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.ProductSpec.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(ProductSpecModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.ProductSpec.FirstOrDefault(m => m.SPCID == model.SPCID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.SPCID = model.SPCID;
                data.ClassID = model.ClassID;
                data.ClassName = model.ClassName;
                data.SpecCode = model.SpecCode;
                data.SpecName = model.SpecName;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.ModifyID = 1;
                data.ModifyName = "Admin";
                data.ModifyTime = DateTime.Now;
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
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
                var data = context.ProductSpec.Where(s => ids.Contains(s.SPCID.ToString())).ToList();
                if (data.Any())
                {
                    context.BatchDelete(data);
                }
                //if (context.Country.Any(m => m.CountryCode == data.CountryCode)) return "该区县信息存在关联数据，不能被删除！";
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }
    }
}
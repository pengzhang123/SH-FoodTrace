using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class ProductTypeAccess : BaseAccess, IProductTypeAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.ProductType.FirstOrDefault(m => m.ProductTypeID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<ProductTypeModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<ProductTypeModel> GetAllEntities()
        {
            return base.Context.ProductType.ToList();
        }

        public ProductTypeModel GetEntityById(int id)
        {
            return base.Context.ProductType.FirstOrDefault(m => m.ProductTypeID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.ProductType.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.ProductType.Where(m => string.IsNullOrEmpty(name) || m.ProductTypeEN == name).Count();
        }

        public ProductTypeModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.ProductType.FirstOrDefault(m => m.ProductTypeID == id && m.ModifyTime == modifyTime);
        }

        public List<ProductTypeModel> GetPagerProductTypeByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.ProductType.Where(m => string.IsNullOrEmpty(name) || m.ProductTypeEN == name)
                                                    .OrderBy(m => m.ProductTypeID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(ProductTypeModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.ProductType.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(ProductTypeModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.ProductType.FirstOrDefault(m => m.ProductTypeID == model.ProductTypeID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.ProductTypeID = model.ProductTypeID;
                data.ProductTypeEN = model.ProductTypeEN;
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
    }
}
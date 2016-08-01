using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class ProductBaseAccess : BaseAccess, IProductBaseAccess
    {
        public int GetEntityCount()
        {
            return base.Context.ProductBase.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.ProductBase.Where(m => string.IsNullOrEmpty(name) || m.ProductName.Contains(name)).Count();
        }

        public List<ProductBaseModel> GetAllEntities()
        {
            return base.Context.ProductBase.ToList();
        }

        public ProductBaseModel GetEntityById(int id)
        {
            return base.Context.ProductBase.FirstOrDefault(m => m.ProductID == id);
        }

        public MessageModel InsertSingleEntity(ProductBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.ProductBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public ProductBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.ProductBase.FirstOrDefault(m => m.ProductID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(ProductBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.ProductBase.FirstOrDefault(m => m.ProductID == model.ProductID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.ProductName = model.ProductName;
                data.ClassID = model.ClassID;
                data.ClassName = model.ClassName;
                data.ProductCode = model.ProductCode;
                data.ProductSpcID = model.ProductSpcID;
                data.ProductTypeID = model.ProductTypeID;
                data.Weight = model.Weight;
                data.PinYinCode = model.PinYinCode;
                data.Price = model.Price;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.ModifyID = 1;
                data.ModifyName = "Admin";
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
                var data = context.ProductBase.FirstOrDefault(m => m.ProductID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                //if (context.Country.Any(m => m.ProductBase.ProductBaseCode == data.ProductBaseCode)) return "该城市信息存在关联数据，不能被删除！";

                context.DeleteAndSave<ProductBaseModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<ProductBaseModel> GetPagerProductBaseByConditions(string name, int pageIndex, int pageSize)
        {
            //var province = Context.Province.FirstOrDefault(m => (!provinceId.HasValue || m.ProvinceID == provinceId));
            return base.Context.ProductBase.Where(m => string.IsNullOrEmpty(name) || m.ProductName.Contains(name))
                    .OrderBy(m => m.ProductID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
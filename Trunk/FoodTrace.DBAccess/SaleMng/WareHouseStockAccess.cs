using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FoodTrace.DBAccess
{
    public class WareHouseStockAccess : BaseAccess, IWareHouseStockAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.WareHouseStock.FirstOrDefault(m => m.StockID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<WareHouseStockModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<WareHouseStockModel> GetAllEntities()
        {
            return base.Context.WareHouseStock.ToList();
        }

        public WareHouseStockModel GetEntityById(int id)
        {
            return base.Context.WareHouseStock.FirstOrDefault(m => m.StockID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.WareHouseStock.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.WareHouseStock.Where(m => m.WareHouseBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.ProductName == name)).Count();
        }

        public WareHouseStockModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.WareHouseStock.FirstOrDefault(m => m.StockID == id && m.ModifyTime == modifyTime);
        }

        public List<WareHouseStockModel> GetPagerWareHouseStockByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.WareHouseStock.Where(m => m.WareHouseBase.CompanyID == companyID
                                                   && (string.IsNullOrEmpty(name) || m.ProductName == name))
                                                   .OrderBy(m => m.StockID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(WareHouseStockModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.WareHouseStock.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(WareHouseStockModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.WareHouseStock.FirstOrDefault(m => m.StockID == model.StockID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.StockID = model.StockID;
                data.ProductID = model.ProductID;
                data.WareHouseID = model.WareHouseID;
                data.ProductName = model.ProductName;
                data.ClassID = model.ClassID;
                data.ClassName = model.ClassName;
                data.ProductCode = model.ProductCode;
                data.ProductSpcID = model.ProductSpcID;
                data.ProductTypeID = model.ProductTypeID;
                data.Weight = model.Weight;
                data.PinYingCode = model.PinYingCode;
                data.StockCount = model.StockCount;
                data.TotalCount = model.TotalCount;
                data.UseCount = model.UseCount;
                data.FreezeCount = model.FreezeCount;
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
    }
}

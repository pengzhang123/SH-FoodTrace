using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodTrace.DBAccess
{
    public class WareHouseDetailAccess : BaseAccess, IWareHouseDetailAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.WareHouseDetail.FirstOrDefault(m => m.DetailID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<WareHouseDetailModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<WareHouseDetailModel> GetAllEntities()
        {
            return base.Context.WareHouseDetail.ToList();
        }

        public WareHouseDetailModel GetEntityById(int id)
        {
            return base.Context.WareHouseDetail.FirstOrDefault(m => m.DetailID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.WareHouseDetail.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.WareHouseDetail.Where(m => m.WareHouseBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.WareHouseEPC == name)).Count();
        }

        public WareHouseDetailModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.WareHouseDetail.FirstOrDefault(m => m.DetailID == id && m.ModifyTime == modifyTime);
        }

        public List<WareHouseDetailModel> GetPagerWareHouseDetailByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.WareHouseDetail.Where(m => m.WareHouseBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.WareHouseEPC == name))
                                                    .OrderBy(m => m.DetailID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(WareHouseDetailModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.WareHouseDetail.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(WareHouseDetailModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.WareHouseDetail.FirstOrDefault(m => m.DetailID == model.DetailID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.DetailID = model.DetailID;
                data.ProductID = model.ProductID;
                data.WareHouseID = model.WareHouseID;
                data.WareHouseEPC = model.WareHouseEPC;
                data.ProductName = model.ProductName;
                data.ClassID = model.ClassID;
                data.ClassName = model.ClassName;
                data.ProductCode = model.ProductCode;
                data.ProductSpcID = model.ProductSpcID;
                data.ProductTypeID = model.ProductTypeID;
                data.Weight = model.Weight;
                data.Price = model.Price;
                data.PinYingCode = model.PinYingCode;
                data.InWareTime = model.InWareTime;
                data.OutWareTime = model.OutWareTime;
                data.WareTemp = model.WareTemp;
                data.WareWet = model.WareWet;
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

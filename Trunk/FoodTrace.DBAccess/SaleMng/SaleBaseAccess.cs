using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FoodTrace.DBAccess
{
    public class SaleBaseAccess : BaseAccess, ISaleBaseAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.SaleBase.FirstOrDefault(m => m.SaleID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<SaleBaseModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<SaleBaseModel> GetAllEntities()
        {
            return base.Context.SaleBase.ToList();
        }

        public SaleBaseModel GetEntityById(int id)
        {
            return base.Context.SaleBase.FirstOrDefault(m => m.SaleID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.SaleBase.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.SaleBase.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.SaleEPC == name)).Count();
        }

        public SaleBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.SaleBase.FirstOrDefault(m => m.SaleID == id && m.ModifyTime == modifyTime);
        }

        public List<SaleBaseModel> GetPagerSaleBaseByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.SaleBase.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.SaleEPC == name))
                                                    .OrderBy(m => m.SaleID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(SaleBaseModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.SaleBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(SaleBaseModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.SaleBase.FirstOrDefault(m => m.SaleID == model.SaleID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.SaleID = model.SaleID;
                data.CompanyID = model.CompanyID;
                data.WareHouseEPC = model.WareHouseEPC;
                data.SaleEPC = model.SaleEPC;
                data.ORCode = model.ORCode;
                data.ChipCode = model.ChipCode;
                data.ProductName = model.ProductName;
                data.ClassID = model.ClassID;
                data.ClassName = model.ClassName;
                data.ProductCode = model.ProductCode;
                data.ProductSpcID = model.ProductSpcID;
                data.ProductTypeID = model.ProductTypeID;
                data.Weight = model.Weight;
                data.Price = model.Price;
                data.PinYingCode = model.PinYingCode;
                data.SaleTime = model.SaleTime;
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
        public SaleBaseModel GetSaleBaseByEPCOrORCode(string Epc, string OrCode)
        {
            return Context.SaleBase.FirstOrDefault(m => (string.IsNullOrEmpty(Epc) || m.SaleEPC == Epc)||(string.IsNullOrEmpty(OrCode) || m.ORCode == OrCode));
        }
    }
}

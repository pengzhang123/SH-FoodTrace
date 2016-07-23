using FoodTrace.IDBAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model;
using FoodTrace.DBManage.IContexts;
using FoodTrace.Common.Libraries;

namespace FoodTrace.DBAccess
{
    public class WareHouseBaseAccess : BaseAccess, IWareHouseBaseAccess
    {
        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.WareHouseBase.FirstOrDefault(m => m.WareHouseID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作";
                context.DeleteAndSave<WareHouseBaseModel>(id);
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public List<WareHouseBaseModel> GetAllEntities()
        {
            return base.Context.WareHouseBase.ToList();
        }

        public WareHouseBaseModel GetEntityById(int id)
        {
            return base.Context.WareHouseBase.FirstOrDefault(m => m.WareHouseID == id);
        }

        public int GetEntityCount()
        {
            return base.Context.WareHouseBase.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.WareHouseBase.Where(m => m.Company.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.WareHouseName == name)).Count();
        }

        public WareHouseBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.WareHouseBase.FirstOrDefault(m => m.WareHouseID == id && m.ModifyTime == modifyTime);
        }

        public List<WareHouseBaseModel> GetPagerWareHouseBaseByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.WareHouseBase.Where(m => m.Company.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.WareHouseName == name))
                                                    .OrderBy(m => m.WareHouseID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public MessageModel InsertSingleEntity(WareHouseBaseModel model)
        {
            Func<IEntityContext, string> operation = (context => {
                context.WareHouseBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            });
            return base.DbOperation(operation);
        }

        public MessageModel UpdateSingleEntity(WareHouseBaseModel model)
        {
            Func<IEntityContext, string> operation = (context =>
            {
                var data = context.WareHouseBase.FirstOrDefault(m => m.WareHouseID == model.WareHouseID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.WareHouseID = model.WareHouseID;
                data.CompanyID = model.CompanyID;
                data.WareHouseCode = model.WareHouseCode;
                data.WareHouseName = model.WareHouseName;
                data.AdminPeople = model.AdminPeople;
                data.WareHouseAddress = model.WareHouseAddress;
                data.WareHouseType = model.WareHouseType;
                data.ChargePeople = model.ChargePeople;
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

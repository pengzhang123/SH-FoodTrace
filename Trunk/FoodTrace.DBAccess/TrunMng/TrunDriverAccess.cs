using FoodTrace.Common.Libraries;
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
    public class TrunDriverAccess : BaseAccess, ITrunDriverAccess
    {
        public int GetEntityCount()
        {
            return base.Context.TrunDriver.Count();
        }

        public int GetEntityCount(int companyID, string name)
        {
            return base.Context.TrunDriver.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.DriverName.Contains(name))).Count();
        }

        public List<TrunDriverModel> GetAllEntities()
        {
            return base.Context.TrunDriver.ToList();
        }

        public TrunDriverModel GetEntityById(int id)
        {
            return base.Context.TrunDriver.FirstOrDefault(m => m.DriverID == id);
        }

        public MessageModel InsertSingleEntity(TrunDriverModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.TrunDriver.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public TrunDriverModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.TrunDriver.FirstOrDefault(m => m.DriverID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(TrunDriverModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.TrunDriver.FirstOrDefault(m => m.DriverID == model.DriverID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.CompanyID = model.CompanyID;
                data.DriverEPC = model.DriverEPC;
                data.DriverName = model.DriverName;
                data.Tel = model.Tel;
                data.Age = model.Age;
                data.Address = model.Address;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.ModifyID = UserManagement.CurrentUser.UserID;
                data.ModifyName = UserManagement.CurrentUser.UserName;
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
                if (context.PlansBatch.Any(m => m.BlockID == id)) return "该地块信息存在关联数据，不能被删除！";

                var data = Context.TrunDriver.FirstOrDefault(m => m.DriverID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<TrunDriverModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<TrunDriverModel> GetPagerTrunDriverByConditions(int companyID, string name, int pageIndex, int pageSize)
        {
            return base.Context.TrunDriver.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(name) || m.DriverName.Contains(name)))
                     .OrderBy(m => m.DriverID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

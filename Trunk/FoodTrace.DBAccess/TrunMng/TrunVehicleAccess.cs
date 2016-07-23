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
    public class TrunVehicleAccess : BaseAccess, ITrunVehicleAccess
    {
        public int GetEntityCount()
        {
            return base.Context.TrunVehicle.Count();
        }

        public int GetEntityCount(int companyID, string carNo)
        {
            return base.Context.TrunVehicle.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(carNo) || m.CarNo.Contains(carNo))).Count();
        }

        public List<TrunVehicleModel> GetAllEntities()
        {
            return base.Context.TrunVehicle.ToList();
        }

        public TrunVehicleModel GetEntityById(int id)
        {
            return base.Context.TrunVehicle.FirstOrDefault(m => m.VehicleID == id);
        }

        public MessageModel InsertSingleEntity(TrunVehicleModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.TrunVehicle.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public TrunVehicleModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.TrunVehicle.FirstOrDefault(m => m.VehicleID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(TrunVehicleModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.TrunVehicle.FirstOrDefault(m => m.VehicleID == model.VehicleID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.CompanyID = model.CompanyID;
                data.CarNo = model.CarNo;
                data.CarCode = model.CarCode;
                data.CarSize = model.CarSize;
                data.MaxTemp = model.MaxTemp;
                data.MinTemp = model.MinTemp;
                data.MaxWet = model.MaxWet;
                data.MinWet = model.MinWet;
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

                var data = Context.TrunVehicle.FirstOrDefault(m => m.VehicleID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<TrunVehicleModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<TrunVehicleModel> GetPagerTrunVehicleByConditions(int companyID, string carNo, int pageIndex, int pageSize)
        {
            return base.Context.TrunVehicle.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(carNo) || m.CarNo.Contains(carNo)))
                     .OrderBy(m => m.VehicleID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

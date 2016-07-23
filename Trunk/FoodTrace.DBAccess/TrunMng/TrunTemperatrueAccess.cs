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
    public class TrunTemperatrueAccess : BaseAccess, ITrunTemperatrueAccess
    {
        public int GetEntityCount()
        {
            return base.Context.TrunTemperatrue.Count();
        }

        public int GetEntityCount(int companyID)
        {
            return base.Context.TrunTemperatrue.Where(m => m.TrunApply.CompanyID == companyID).Count();
        }

        public List<TrunTemperatrueModel> GetAllEntities()
        {
            return base.Context.TrunTemperatrue.ToList();
        }

        public TrunTemperatrueModel GetEntityById(int id)
        {
            return base.Context.TrunTemperatrue.FirstOrDefault(m => m.TemperatureID == id);
        }

        public MessageModel InsertSingleEntity(TrunTemperatrueModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.TrunTemperatrue.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public TrunTemperatrueModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.TrunTemperatrue.FirstOrDefault(m => m.TemperatureID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(TrunTemperatrueModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.TrunTemperatrue.FirstOrDefault(m => m.TemperatureID == model.TemperatureID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.ApplyID = model.ApplyID;
                data.TrunApply = model.TrunApply;
                data.PickTime = model.PickTime;
                data.Temperature = model.Temperature;
                data.Lon = model.Lon;
                data.Lat = model.Lat;
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

                var data = Context.TrunTemperatrue.FirstOrDefault(m => m.TemperatureID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<TrunTemperatrueModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<TrunTemperatrueModel> GetPagerTrunTemperatrueByConditions(int companyID, int pageIndex, int pageSize)
        {
            return base.Context.TrunTemperatrue.Where(m => m.TrunApply.CompanyID == companyID)
                     .OrderBy(m => m.TemperatureID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

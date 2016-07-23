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
    public class TrunApplyAccess : BaseAccess, ITrunApplyAccess
    {
        public int GetEntityCount()
        {
            return base.Context.TrunApply.Count();
        }

        public int GetEntityCount(int companyID, string applyNo)
        {
            return base.Context.TrunApply.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(applyNo) || m.ApplyNo.Contains(applyNo))).Count();
        }

        public List<TrunApplyModel> GetAllEntities()
        {
            return base.Context.TrunApply.ToList();
        }

        public TrunApplyModel GetEntityById(int id)
        {
            return base.Context.TrunApply.FirstOrDefault(m => m.ApplyID == id);
        }

        public MessageModel InsertSingleEntity(TrunApplyModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.TrunApply.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public TrunApplyModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.TrunApply.FirstOrDefault(m => m.ApplyID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(TrunApplyModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.TrunApply.FirstOrDefault(m => m.ApplyID == model.ApplyID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.CompanyID = model.CompanyID;
                data.VehicleID = model.VehicleID;
                data.DriverID = model.DriverID;
                data.ApplyNo = model.ApplyNo;
                data.MaxTemp = model.MaxTemp;
                data.MinTemp = model.MinTemp;
                data.MaxWet = model.MaxWet;
                data.MinWet = model.MinWet;
                data.StartTime = model.StartTime;
                data.StartAddress = model.StartAddress;
                data.EndTime = model.EndTime;
                data.EndAddress = model.EndAddress;
                data.Sender = model.Sender;
                data.Receiver = model.Receiver;
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

                var data = Context.TrunApply.FirstOrDefault(m => m.ApplyID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<TrunApplyModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<TrunApplyModel> GetPagerTrunApplyByConditions(int companyID, string applyNo, int pageIndex, int pageSize)
        {
            return base.Context.TrunApply.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(applyNo) || m.ApplyNo.Contains(applyNo)))
                     .OrderBy(m => m.ApplyID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

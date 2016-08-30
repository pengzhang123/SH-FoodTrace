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
    public class ShadowProcessAccess : BaseAccess, IShadowProcessAccess
    {
        public int GetEntityCount()
        {
            return base.Context.ShadowProcess.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.ShadowProcess.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.ProcessBatch.Contains(code))).Count();
        }

        public List<ShadowProcessModel> GetAllEntities()
        {
            return base.Context.ShadowProcess.ToList();
        }

        public ShadowProcessModel GetEntityById(int id)
        {
            return base.Context.ShadowProcess.FirstOrDefault(m => m.SPIndex == id);
        }

        public MessageModel InsertSingleEntity(ShadowProcessModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                model.ModifyID = UserManagement.CurrentUser.UserID;
                model.ModifyName = UserManagement.CurrentUser.UserName;
                model.ModifyTime = DateTime.Now;
                context.ShadowProcess.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public ShadowProcessModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.ShadowProcess.FirstOrDefault(m => m.SPIndex == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(ShadowProcessModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.ShadowProcess.FirstOrDefault(m => m.SPIndex == model.SPIndex && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.ProcessID = model.ProcessID;
                data.ShadowID = model.ShadowID;
                data.CompanyID = model.CompanyID;
                data.ProcessBatch = model.ProcessBatch;
                data.ProcessCode = model.ProcessCode;
                data.ProcessName = model.ProcessName;
                data.WorkPeople = model.WorkPeople;
                data.Weight = model.Weight;
                data.Price = model.Price;
                data.Remark = model.Remark;
                data.SortID = model.SortID;
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
                var data = Context.ShadowProcess.FirstOrDefault(m => m.SPIndex == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<ShadowProcessModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<ShadowProcessModel> GetPagerShadowProcessByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.ShadowProcess.Where(m => m.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.ProcessBatch.Contains(code)))
                     .OrderBy(m => m.SPIndex).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

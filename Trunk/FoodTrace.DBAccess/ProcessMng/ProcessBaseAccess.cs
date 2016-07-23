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
    public class ProcessBaseAccess : BaseAccess, IProcessBaseAccess
    {
        public int GetEntityCount()
        {
            return base.Context.ProcessBase.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.ProcessBase.Where(m => (string.IsNullOrEmpty(name) || m.ProcessName.Contains(name))).Count();
        }

        public List<ProcessBaseModel> GetAllEntities()
        {
            return base.Context.ProcessBase.ToList();
        }

        public ProcessBaseModel GetEntityById(int id)
        {
            return base.Context.ProcessBase.FirstOrDefault(m => m.ProcessID == id);
        }

        public MessageModel InsertSingleEntity(ProcessBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.ProcessBase.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public ProcessBaseModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.ProcessBase.FirstOrDefault(m => m.ProcessID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(ProcessBaseModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.ProcessBase.FirstOrDefault(m => m.ProcessID == model.ProcessID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.ProcessClass = model.ProcessClass;
                data.ProcessCode = model.ProcessCode;
                data.ProcessName = model.ProcessName;
                data.Weight = model.Weight;
                data.Price = model.Price;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.SortID = model.SortID;
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
                if (context.ShadowProcess.Any(m => m.ProcessID == id)) return "该加工工序信息存在关联数据，不能被删除！";

                var data = Context.ProcessBase.FirstOrDefault(m => m.ProcessID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<ProcessBaseModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<ProcessBaseModel> GetPagerProcessBaseByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.ProcessBase.Where(m => (string.IsNullOrEmpty(name) || m.ProcessName.Contains(name)))
                     .OrderBy(m => m.ProcessID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

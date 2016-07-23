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
    public class CodeMaxAccess : BaseAccess, ICodeMaxAccess
    {
        public int GetEntityCount()
        {
            return base.Context.CodeMax.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.CodeMax.Where(m => (string.IsNullOrEmpty(name) || m.ObjectName.Contains(name))).Count();
        }

        public List<CodeMaxModel> GetAllEntities()
        {
            return base.Context.CodeMax.ToList();
        }

        public CodeMaxModel GetEntityById(int id)
        {
            return base.Context.CodeMax.FirstOrDefault(m => m.CodeMaxID == id);
        }

        public MessageModel InsertSingleEntity(CodeMaxModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.CodeMax.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public CodeMaxModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.CodeMax.FirstOrDefault(m => m.CodeMaxID == id /*&& m.ModifyTime == modifyTime*/);
        }

        public MessageModel UpdateSingleEntity(CodeMaxModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.CodeMax.FirstOrDefault(m => m.CodeMaxID == model.CodeMaxID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.ObjectCode = model.ObjectCode;
                data.ObjectName = model.ObjectName;
                data.ObjectValue = model.ObjectValue;
                data.SortID = model.SortID;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
                data.ModifyID = model.ModifyID;
                data.ModifyName = model.ModifyName;
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
                var data = context.CodeMax.FirstOrDefault(m => m.CodeMaxID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<CodeMaxModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<CodeMaxModel> GetPagerCodeMaxByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.CodeMax.Where(m => (string.IsNullOrEmpty(name) || m.ObjectName.Contains(name)))
                    .OrderBy(m => m.CodeMaxID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

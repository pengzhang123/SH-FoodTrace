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
    public class CodeObjectAccess : BaseAccess, ICodeObjectAccess
    {
        public int GetEntityCount()
        {
            return base.Context.CodeObject.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.CodeObject.Where(m => (string.IsNullOrEmpty(name) || m.ObjectName.Contains(name))).Count();
        }

        public List<CodeObjectModel> GetAllEntities()
        {
            return base.Context.CodeObject.ToList();
        }

        public CodeObjectModel GetEntityById(int id)
        {
            return base.Context.CodeObject.FirstOrDefault(m => m.ObjectID == id);
        }

        public MessageModel InsertSingleEntity(CodeObjectModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.CodeObject.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public CodeObjectModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.CodeObject.FirstOrDefault(m => m.ObjectID == id /*&& m.ModifyTime == modifyTime*/);
        }

        public MessageModel UpdateSingleEntity(CodeObjectModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.CodeObject.FirstOrDefault(m => m.ObjectID == model.ObjectID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.ObjectCode = model.ObjectCode;
                data.ObjectName = model.ObjectName;
                data.Prefix = model.Prefix;
                data.MaxLength = model.MaxLength;
                data.SeqLength = model.SeqLength;
                data.IsFixedLength = model.IsFixedLength;
                data.IsAuto = model.IsAuto;
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
                var data = context.CodeObject.FirstOrDefault(m => m.ObjectID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<CodeObjectModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteCodeObjectByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var data = context.CodeObject.Where(m =>ids.Contains(m.ObjectID.ToString())).ToList();
                if (data.Any())
                {
                    context.BatchDelete(data);
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }
        public List<CodeObjectModel> GetPagerCodeObjectByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.CodeObject.Where(m => (string.IsNullOrEmpty(name) || m.ObjectName.Contains(name)))
                    .OrderBy(m => m.ObjectID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

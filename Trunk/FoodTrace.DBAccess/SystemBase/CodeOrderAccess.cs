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
    public class CodeOrderAccess : BaseAccess, ICodeOrderAccess
    {
        public int GetEntityCount()
        {
            return base.Context.CodeOrder.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.CodeOrder.Where(m => (string.IsNullOrEmpty(name) || m.ObjectName.Contains(name))).Count();
        }

        public List<CodeOrderModel> GetAllEntities()
        {
            return base.Context.CodeOrder.ToList();
        }

        public CodeOrderModel GetEntityById(int id)
        {
            return base.Context.CodeOrder.FirstOrDefault(m => m.OrderID == id);
        }

        public MessageModel InsertSingleEntity(CodeOrderModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.CodeOrder.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public CodeOrderModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.CodeOrder.FirstOrDefault(m => m.OrderID == id /*&& m.ModifyTime == modifyTime*/);
        }

        public MessageModel UpdateSingleEntity(CodeOrderModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.CodeOrder.FirstOrDefault(m => m.OrderID == model.OrderID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.ObjectCode = model.ObjectCode;
                data.ObjectName = model.ObjectName;
                data.Prefix = model.Prefix;
                data.DateFormat = model.DateFormat;
                data.SeqType = model.SeqType;
                data.MaxLength = model.MaxLength;
                data.SeqLength = model.SeqLength;
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
                var data = context.CodeOrder.FirstOrDefault(m => m.OrderID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<CodeOrderModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<CodeOrderModel> GetPagerCodeOrderByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.CodeOrder.Where(m => (string.IsNullOrEmpty(name) || m.ObjectName.Contains(name)))
                    .OrderBy(m => m.OrderID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var data = context.CodeOrder.Where(m =>ids.Contains(m.OrderID.ToString())).ToList();
                if (data.Any())
                {
                    context.BatchDelete(data);
                }
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }
    }
}
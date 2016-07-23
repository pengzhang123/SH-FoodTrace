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
  public class TidAccess : BaseAccess, ITidAccess
    {
        public int GetEntityCount()
        {
            return base.Context.TID.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.Area.Where(m => (string.IsNullOrEmpty(name) || m.AreaName.Contains(name))).Count();
        }

        public List<TIDModel> GetAllEntities()
        {
            return base.Context.TID.ToList();
        }

        public TIDModel GetEntityById(int id)
        {
            return base.Context.TID.FirstOrDefault(m => m.TID == id);
        }

        public TIDModel GetEntityByChipCode(string code)
        {
            return base.Context.TID.FirstOrDefault(m => m.ChipCode == code);
        }

        public MessageModel InsertSingleEntity(TIDModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.TID.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public TIDModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.TID.FirstOrDefault(m => m.TID == id /*&& m.ModifyTime == modifyTime*/);
        }

        public MessageModel UpdateSingleEntity(TIDModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.TID.FirstOrDefault(m => m.TID == model.TID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.IsUse = model.IsUse;
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                if (context.Province.Any(m => m.AreaID == id)) return "该区域信息存在关联数据，不能被删除！";

                var data = context.Area.FirstOrDefault(m => m.AreaID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                context.DeleteAndSave<TIDModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<TIDModel> GetPagerTidByConditions(int pageIndex, int pageSize)
        {
            return base.Context.TID.OrderBy(m => m.TID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}

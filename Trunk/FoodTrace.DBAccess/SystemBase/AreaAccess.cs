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
    public class AreaAccess : BaseAccess, IAreaAccess
    {
        public int GetEntityCount()
        {
            return base.Context.Area.Count();
        }

        public int GetEntityCount(string name)
        {
            return base.Context.Area.Where(m => (string.IsNullOrEmpty(name) || m.AreaName.Contains(name))).Count();
        }

        public List<AreaModel> GetAllEntities()
        {
            return base.Context.Area.ToList();
        }

        public AreaModel GetEntityById(int id)
        {
            return base.Context.Area.FirstOrDefault(m => m.AreaID == id);
        }

        public MessageModel InsertSingleEntity(AreaModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.Area.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public AreaModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.Area.FirstOrDefault(m => m.AreaID == id /*&& m.ModifyTime == modifyTime*/);
        }

        public MessageModel UpdateSingleEntity(AreaModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.Area.FirstOrDefault(m => m.AreaID == model.AreaID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.AreaName = model.AreaName;
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
                context.DeleteAndSave<AreaModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<AreaModel> GetPagerAreaByConditions(string name, int pageIndex, int pageSize)
        {
            return base.Context.Area.Where(m => (string.IsNullOrEmpty(name) || m.AreaName.Contains(name)))
                    .OrderBy(m => m.AreaID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

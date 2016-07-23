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
    public class ProvinceAccess : BaseAccess, IProvinceAccess
    {
        public int GetEntityCount()
        {
            return base.Context.Province.Count();
        }

        public int GetEntityCount(int? areaId, string name)
        {
            return base.Context.Province.Where(m => (areaId.HasValue || m.AreaID == areaId.Value)
                                                    && (string.IsNullOrEmpty(name) || m.ProvinceName.Contains(name))).Count();
        }

        public List<ProvinceModel> GetAllEntities()
        {
            return base.Context.Province.ToList();
        }

        public ProvinceModel GetEntityById(int id)
        {
            return base.Context.Province.FirstOrDefault(m => m.ProvinceID == id);
        }

        public MessageModel InsertSingleEntity(ProvinceModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.Province.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public ProvinceModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.Province.FirstOrDefault(m => m.ProvinceID == id /*&& m.ModifyTime == modifyTime*/);
        }

        public MessageModel UpdateSingleEntity(ProvinceModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.Province.FirstOrDefault(m => m.ProvinceID == model.ProvinceID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.ProvinceCode = model.ProvinceCode;
                data.ProvinceName = model.ProvinceName;
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public MessageModel DeleteSingleEntity(int id)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.Province.FirstOrDefault(m => m.ProvinceID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                if (context.City.Any(m => m.Province.ProvinceCode == data.ProvinceCode)) return "该区域信息存在关联数据，不能被删除！";

                context.DeleteAndSave<ProvinceModel>(data);
                return string.Empty;
            };

            return base.DbOperationInTransaction(operation);
        }

        public List<ProvinceModel> GetPagerProvinceByConditions(int? areaId, string name, int pageIndex, int pageSize)
        {
            return base.Context.Province.Where(m => (!areaId.HasValue || m.AreaID == areaId.Value)
                                                && (string.IsNullOrEmpty(name) || m.ProvinceName.Contains(name)))
                    .OrderBy(m => m.ProvinceID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

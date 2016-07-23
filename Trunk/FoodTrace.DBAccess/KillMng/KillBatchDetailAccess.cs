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
    public class KillBatchDetailAccess : BaseAccess, IKillBatchDetailAccess
    {
        public int GetEntityCount()
        {
            return base.Context.KillBatchDetail.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.KillBatchDetail.Where(m => m.KillBatch.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.CultivationEpc.Contains(code))).Count();
        }

        public List<KillBatchDetailModel> GetAllEntities()
        {
            return base.Context.KillBatchDetail.ToList();
        }

        public List<KillBatchDetailModel> GetAllEntities(int batchId)
        {
            return base.Context.KillBatchDetail.Where(m => m.KillBatchID == batchId).ToList();
        }

        public KillBatchDetailModel GetEntityById(int id)
        {
            return base.Context.KillBatchDetail.FirstOrDefault(m => m.DetailID == id);
        }

        public MessageModel InsertSingleEntity(KillBatchDetailModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.KillBatchDetail.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public KillBatchDetailModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.KillBatchDetail.FirstOrDefault(m => m.DetailID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(KillBatchDetailModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.KillBatchDetail.FirstOrDefault(m => m.DetailID == model.DetailID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.KillBatchID = model.KillBatchID;
                data.CultivationID = model.CultivationID;
                data.BreedID = model.BreedID;
                data.AreaID = model.AreaID;
                data.HomeID = model.HomeID;
                data.CultivationEpc = model.CultivationEpc;
                data.Remark = model.Remark;
                data.IsLocked = model.IsLocked;
                data.IsShow = model.IsShow;
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
                //if (context.KillBatchDetail.Any(m => m.KillBatchDetailID == id)) return "该屠宰批次信息存在关联数据，不能被删除！";

                var data = Context.KillBatchDetail.FirstOrDefault(m => m.DetailID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<KillBatchDetailModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<KillBatchDetailModel> GetPagerKillBatchDetailByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.KillBatchDetail.Where(m => m.KillBatch.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.CultivationEpc.Contains(code)))
                     .OrderBy(m => m.DetailID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}

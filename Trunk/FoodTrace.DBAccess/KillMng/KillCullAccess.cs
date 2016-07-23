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
    public class KillCullAccess : BaseAccess, IKillCullAccess
    {
        public int GetEntityCount()
        {
            return base.Context.KillCull.Count();
        }

        //public int GetEntityCount(int companyID)
        //{
        //    return base.Context.KillCull.Where(m => m.CompanyID == companyID).Count();
        //}

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.KillCull.Where(m => m.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.CultivationEpc.Contains(code))).Count();
        }

        public List<KillCullModel> GetAllEntities()
        {
            return base.Context.KillCull.ToList();
        }

        public KillCullModel GetEntityById(int id)
        {
            return base.Context.KillCull.FirstOrDefault(m => m.KillCullID == id);
        }

        public MessageModel InsertSingleEntity(KillCullModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.KillCull.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public KillCullModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.KillCull.FirstOrDefault(m => m.KillCullID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(KillCullModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.KillCull.FirstOrDefault(m => m.KillCullID == model.KillCullID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.CompanyID = model.CompanyID;
                data.KillBatchID = model.KillBatchID;
                data.CultivationID = model.CultivationID;
                data.CultivationEpc = model.CultivationEpc;
                data.KillEpc = model.KillEpc;
                data.ProductID = model.ProductID;
                data.ProductName = model.ProductName;
                data.Weight = model.Weight;
                data.Flow = model.Flow;
                data.KillTime = model.KillTime;
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
                if (context.KillDrug.Any(m => m.KillCullID == id)) return "该屠宰转换信息存在关联数据，不能被删除！";

                var data = Context.KillCull.FirstOrDefault(m => m.KillCullID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<KillCullModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<KillCullModel> GetPagerKillCullByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.KillCull.Where(m => m.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.CultivationEpc.Contains(code)))
                     .OrderBy(m => m.KillCullID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public KillCullModel GetKillCullByEPCOrORCode(string Epc, string OrCode)
        {
            return Context.KillCull.FirstOrDefault(m => string.IsNullOrEmpty(Epc) || m.KillEpc == Epc);
        }
    }
}

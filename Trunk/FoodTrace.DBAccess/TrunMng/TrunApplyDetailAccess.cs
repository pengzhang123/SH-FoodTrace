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
    public class TrunApplyDetailAccess : BaseAccess, ITrunApplyDetailAccess
    {
        public int GetEntityCount()
        {
            return base.Context.TrunApplyDetail.Count();
        }

        public int GetEntityCount(int companyID, string applyNo)
        {
            return base.Context.TrunApplyDetail.Where(m => m.TrunApply.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(applyNo) || m.TrunApply.ApplyNo.Contains(applyNo))).Count();
        }

        public List<TrunApplyDetailModel> GetAllEntities()
        {
            return base.Context.TrunApplyDetail.ToList();
        }

        public TrunApplyDetailModel GetEntityById(int id)
        {
            return base.Context.TrunApplyDetail.FirstOrDefault(m => m.DetailID == id);
        }

        public MessageModel InsertSingleEntity(TrunApplyDetailModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.TrunApplyDetail.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public TrunApplyDetailModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.TrunApplyDetail.FirstOrDefault(m => m.DetailID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(TrunApplyDetailModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.TrunApplyDetail.FirstOrDefault(m => m.DetailID == model.DetailID && m.ModifyTime == model.ModifyTime);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.ApplyID = model.ApplyID;
                data.ProductID = model.ProductID;
                data.ProductName = model.ProductName;
                data.TrunEPC = model.TrunEPC;
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
                if (context.PlansBatch.Any(m => m.BlockID == id)) return "该地块信息存在关联数据，不能被删除！";

                var data = Context.TrunApplyDetail.FirstOrDefault(m => m.DetailID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<TrunApplyDetailModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<TrunApplyDetailModel> GetPagerTrunApplyDetailByConditions(int companyID, string applyNo, int pageIndex, int pageSize)
        {
            return base.Context.TrunApplyDetail.Where(m => m.TrunApply.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(applyNo) || m.TrunApply.ApplyNo.Contains(applyNo)))
                     .OrderBy(m => m.DetailID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public TrunApplyDetailModel GetTrunApplyDetailByEPCOrORCode(string Epc, string OrCode)
        {
            return Context.TrunApplyDetail.FirstOrDefault(m => string.IsNullOrEmpty(Epc) || m.TrunEPC == Epc);
        }
    }
}

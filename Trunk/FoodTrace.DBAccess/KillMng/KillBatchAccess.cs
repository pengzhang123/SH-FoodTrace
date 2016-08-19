using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class KillBatchAccess : BaseAccess, IKillBatchAccess
    {
        public int GetEntityCount()
        {
            return base.Context.KillBatch.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.KillBatch.Where(m => m.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.BatchNO.Contains(code))).Count();
        }

        public List<KillBatchModel> GetAllEntities()
        {
            return base.Context.KillBatch.ToList();
        }
        
        public KillBatchModel GetEntityById(int id)
        {
            return base.Context.KillBatch.FirstOrDefault(m => m.KillBatchID == id);
        }

        public MessageModel InsertSingleEntity(KillBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                model.CompanyID = UserManagement.CurrentUser.CompanyId;
                context.KillBatch.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public KillBatchModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.KillBatch.FirstOrDefault(m => m.KillBatchID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(KillBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.KillBatch.FirstOrDefault(m => m.KillBatchID == model.KillBatchID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.KillBatchID = model.KillBatchID;
                data.CompanyID =UserManagement.CurrentUser.CompanyId;
                data.BatchNO = model.BatchNO;
                data.RecvicePeople = model.RecvicePeople;
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
                if (context.KillBatchDetail.Any(m => m.KillBatchID == id)) return "该屠宰批次信息存在关联数据，不能被删除！";

                var data = Context.KillBatch.FirstOrDefault(m => m.KillBatchID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<KillBatchModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<KillBatchModel> GetPagerKillBatchByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.KillBatch.Where(m => m.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.BatchNO.Contains(code)))
                     .OrderBy(m => m.KillBatchID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 屠宰批次列表
        /// </summary>
        /// <param name="comId"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<KillBatchDto> GetKillBatchListPaging(int comId, int pIndex, int pSize)
        {
            var query = (from s in Context.KillBatch
                join com in Context.Company on s.CompanyID equals com.CompanyID
                where s.CompanyID == comId
                select new KillBatchDto()
                {
                    KillBatchID = s.KillBatchID,
                    CompanyID = s.CompanyID,
                    CompanyName = com.CompanyName,
                    BatchNO = s.BatchNO,
                    RecvicePeople = s.RecvicePeople,
                    Remark = s.Remark,
                    IsLocked = s.IsLocked,
                    IsShow = s.IsShow
                }).AsQueryable();

            var list = query.OrderBy(s=>s.KillBatchID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();
             return new GridList<KillBatchDto>(){rows = list,total=query.Count()};
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KillBatchDto GetKillBatchDtoById(int id)
        {
            var query = (from s in Context.KillBatch
                        where s.KillBatchID==id
                         select new KillBatchDto()
                         {
                             KillBatchID = s.KillBatchID,
                             CompanyID = s.CompanyID,
                             BatchNO = s.BatchNO,
                             RecvicePeople = s.RecvicePeople,
                             Remark = s.Remark,
                             IsLocked = s.IsLocked,
                             IsShow = s.IsShow
                         }).FirstOrDefault();

            return query;
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
                var idArray = ids.Split(',');
                var list = context.KillBatch.Where(s => idArray.Contains(s.KillBatchID.ToString())).ToList();
                if (list.Any())
                {
                    context.BatchDelete(list);
                }

                return string.Empty;
            };

            return base.DbOperation(operation);
        }
    }
}

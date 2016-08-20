using FoodTrace.Common.Libraries;
using FoodTrace.DBManage.IContexts;
using FoodTrace.IDBAccess;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.DBAccess
{
    public class KillDrugAccess : BaseAccess, IKillDrugAccess
    {
        public int GetEntityCount()
        {
            return base.Context.KillDrug.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.KillDrug.Where(m => m.KillCull.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.KillEpc.Contains(code))).Count();
        }

        public List<KillDrugModel> GetAllEntities()
        {
            return base.Context.KillDrug.ToList();
        }

        public KillDrugModel GetEntityById(int id)
        {
            return base.Context.KillDrug.FirstOrDefault(m => m.DrugID == id);
        }

        public MessageModel InsertSingleEntity(KillDrugModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.KillDrug.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public KillDrugModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.KillDrug.FirstOrDefault(m => m.DrugID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(KillDrugModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.KillDrug.FirstOrDefault(m => m.DrugID == model.DrugID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";
                data.KillCullID = model.KillCullID;
                data.KillEpc = model.KillEpc;
                data.People = model.People;
                data.DrugTime = model.DrugTime;
                data.IsNormal = model.IsNormal;
                data.Pic = model.Pic;
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
                //if (context.KillDrug.Any(m => m.DrugID == id)) return "该屠宰转换信息存在关联数据，不能被删除！";

                var data = Context.KillDrug.FirstOrDefault(m => m.DrugID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<KillDrugModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<KillDrugModel> GetPagerKillDrugByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.KillDrug.Where(m => m.KillCull.CompanyID == companyID
                                                && (string.IsNullOrEmpty(code) || m.KillEpc.Contains(code)))
                     .OrderBy(m => m.DrugID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="comid"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<KillDrugDto> GetKillDrugListPaging(int comid, int pIndex, int pSize)
        {
            var query = (from s in Context.KillDrug
                join batch in Context.KillCull on s.KillCullID equals batch.KillCullID
                join com in Context.Company on batch.CompanyID equals com.CompanyID
                where com.CompanyID == comid
                select new KillDrugDto()
                {
                    DrugID = s.DrugID,
                    KillCullID = s.KillCullID,
                    KillEpc = s.KillEpc,
                    People = s.People,
                    DrugTime = s.DrugTime,
                    IsNormal = s.IsNormal,
                    Remark = s.Remark,
                    IsLocked = s.IsLocked,
                    IsShow = s.IsShow
                }).AsQueryable();

            var list = query.OrderBy(s => s.DrugID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();

            return new GridList<KillDrugDto>(){rows = list,total = query.Count()};

        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public KillDrugDto GetKillDrugDtoById(int id)
        {
            var query = (from s in Context.KillDrug
                         where s.DrugID==id
                         select new KillDrugDto()
                         {
                             DrugID = s.DrugID,
                             KillCullID = s.KillCullID,
                             KillEpc = s.KillEpc,
                             People = s.People,
                             DrugTime = s.DrugTime,
                             IsNormal = s.IsNormal,
                             Remark = s.Remark,
                             IsLocked = s.IsLocked,
                             IsShow = s.IsShow
                         }).FirstOrDefault();

            return query;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {
                var idArray = ids.Split(',');
                var list = context.KillDrug.Where(s => idArray.Contains(s.DrugID.ToString())).ToList();
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

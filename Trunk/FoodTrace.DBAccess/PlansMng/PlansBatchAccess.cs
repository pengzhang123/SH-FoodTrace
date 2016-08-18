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
    /// <summary>
    /// 批次产品种植计划
    /// </summary>
    public class PlansBatchAccess : BaseAccess, IPlansBatchAccess
    {
        public int GetEntityCount()
        {
            return base.Context.PlansBatch.Count();
        }

        public int GetEntityCount(int companyID, string code)
        {
            return base.Context.PlansBatch.Where(m => m.LandBlock.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.BatchCode.Contains(code))).Count();
        }

        public List<PlansBatchModel> GetAllEntities()
        {
            return base.Context.PlansBatch.ToList();
        }

        public PlansBatchModel GetEntityById(int id)
        {
            return base.Context.PlansBatch.FirstOrDefault(m => m.BatchID == id);
        }

        public MessageModel InsertSingleEntity(PlansBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                context.PlansBatch.Add(model);
                context.SaveChanges();
                return string.Empty;
            };
            return base.DbOperation(operation);
        }

        public PlansBatchModel GetOriEntity(int id, DateTime? modifyTime)
        {
            return base.Context.PlansBatch.FirstOrDefault(m => m.BatchID == id && m.ModifyTime == modifyTime);
        }

        public MessageModel UpdateSingleEntity(PlansBatchModel model)
        {
            Func<IEntityContext, string> operation = delegate (IEntityContext context)
            {
                var data = context.PlansBatch.FirstOrDefault(m => m.BatchID == model.BatchID);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                data.BlockID = model.BlockID;
                data.SeedID = model.SeedID;
                data.BatchNO = model.BatchNO;
                data.BatchCode = model.BatchCode;
                data.PlansTime = model.PlansTime;
                data.PlansYear = model.PlansYear;
                data.HarvestTime = model.HarvestTime;
                data.PlansArea = model.PlansArea;
                data.ChargePerson = model.ChargePerson;
                data.HarvestCount = model.HarvestCount;
                data.RealCount = model.RealCount;
                data.People = model.People;
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
                if (context.PlansDrug.Any(m => m.BatchID == id) || context.PlansFert.Any(m => m.BatchID == id)) return "该种植计划信息存在关联数据，不能被删除！";

                var data = Context.PlansBatch.FirstOrDefault(m => m.BatchID == id);
                if (data == null) return "当前数据不存在或被更新，请刷新后再次操作！";

                context.DeleteAndSave<PlansBatchModel>(id);
                return string.Empty;
            };

            return base.DbOperation(operation);
        }

        public List<PlansBatchModel> GetPagerPlansBatchByConditions(int companyID, string code, int pageIndex, int pageSize)
        {
            return base.Context.PlansBatch.Where(m => m.LandBlock.LandBase.CompanyID == companyID
                                                    && (string.IsNullOrEmpty(code) || m.BatchCode.Contains(code)))
                    .OrderBy(m => m.BatchID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public PlansBatchModel GetPlansBatchByEPCOrORCode(string Epc, string OrCode)
        {
            return Context.PlansBatch.FirstOrDefault(m => string.IsNullOrEmpty(Epc) || m.BatchCode == Epc);
        }


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<PlatPlanDto> GetPlatPlanList(int pIndex, int pSize)
        {
            var query = (from s in Context.PlansBatch
                         join lb in Context.LandBlock on s.BlockID equals lb.BlockID into lbl
                         from lbleft in lbl.DefaultIfEmpty()
                         join ls in Context.SeedBase on s.SeedID equals ls.SeedID into lsl
                         from lsleft in lsl.DefaultIfEmpty()
                select new PlatPlanDto()
                {
                    BatchID = s.BatchID,
                    BlockID = s.BlockID,
                    BlockName = lbleft.BlockName,
                    SeedName = lsleft.SeedName,
                    SeedID = s.SeedID,
                    BatchNO = s.BatchNO,
                    BatchCode = s.BatchCode,
                    PlansTime = s.PlansTime,
                    PlansYear = s.PlansYear,
                    HarvestTime = s.HarvestTime,
                    PlansArea = s.PlansArea,
                    ChargePerson = s.ChargePerson,
                    HarvestCount = s.HarvestCount,
                    RealCount = s.RealCount,
                    People = s.People,
                    Remark = s.Remark,
                    IsLocked = s.IsLocked,
                    IsShow = s.IsShow
                }).AsQueryable();

            var list = query.OrderBy(s=>s.BatchID).Skip((pIndex - 1)*pSize).Take(pSize).ToList();

            return new GridList<PlatPlanDto>(){rows = list,total = query.Count()};
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlatPlanDto GetPlatPlanDtoById(int id)
        {
            var model = (from s in Context.PlansBatch
                         where s.BatchID==id
                         select new PlatPlanDto()
                         {
                             BatchID = s.BatchID,
                             BlockID = s.BlockID,
                             SeedID = s.SeedID,
                             BatchNO = s.BatchNO,
                             BatchCode = s.BatchCode,
                             PlansTime = s.PlansTime,
                             PlansYear = s.PlansYear,
                             HarvestTime = s.HarvestTime,
                             PlansArea = s.PlansArea,
                             ChargePerson = s.ChargePerson,
                             HarvestCount = s.HarvestCount,
                             RealCount = s.RealCount,
                             People = s.People,
                             Remark = s.Remark,
                             IsLocked = s.IsLocked,
                             IsShow = s.IsShow
                         }).FirstOrDefault();

            return model;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DleteByIds(string ids)
        {
            Func<IEntityContext, string> operation = delegate(IEntityContext context)
            {

                var idArray = ids.Split(',');
                var list = context.PlansBatch.Where(s => idArray.Contains(s.BatchID.ToString())).ToList();

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

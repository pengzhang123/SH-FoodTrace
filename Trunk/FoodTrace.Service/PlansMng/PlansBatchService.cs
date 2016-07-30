using FoodTrace.Common.Libraries;
using FoodTrace.DBAccess;
using FoodTrace.IDBAccess;
using FoodTrace.IService;
using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Service
{
    /// <summary>
    /// 种植计划管理
    /// </summary>
    public class PlansBatchService : BaseService, IPlansBatchService
    {
        private IPlansBatchAccess plansBatchAccess;
        private ILandBlockAccess landBlockAccess;
        private ISeedBaseAccess seedBaseAccess;
        public PlansBatchService()
        {
            plansBatchAccess = BaseAccess.CreateAccess<IPlansBatchAccess>(AccessMappingKey.PlansBatchAccess.ToString());
            landBlockAccess = BaseAccess.CreateAccess<ILandBlockAccess>(AccessMappingKey.LandBlockAccess.ToString());
            seedBaseAccess = BaseAccess.CreateAccess<ISeedBaseAccess>(AccessMappingKey.SeedBaseAccess.ToString());
        }

        /// <summary>
        /// 获取PlansBatch总条数
        /// </summary>
        /// <returns></returns>
        public int GetPlansBatchCount()
        {
            return plansBatchAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取PlansBatch总条数
        /// </summary>
        /// <param name="code">查询条件：批次溯源码（模糊查询）</param>
        /// <returns></returns>
        public int GetPlansBatchCount(string code)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return plansBatchAccess.GetEntityCount(companyID, code.Trim());
        }

        /// <summary>
        /// 获取当前用户所在公司的种植计划（分页）
        /// </summary>
        /// <param name="name">查询条件：批次溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<PlansBatchModel> GetPagerPlansBatch(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = plansBatchAccess.GetPagerPlansBatchByConditions(companyID, code.Trim(), pageIndex, pageSize);
            //foreach (var item in result)
            //{
            //    SetLandBlock(item);
            //    SetSeedBase(item);
            //}
            return result;
        }

        /// <summary>
        /// 通过ID获取PlansBatch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlansBatchModel GetPlansBatchById(int id)
        {
            return plansBatchAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条PlansBatch
        /// </summary>
        /// <param name="model">种植计划实体</param>
        /// <returns></returns>
        public MessageModel InsertSinglePlansBatch(PlansBatchModel model)
        {
            return plansBatchAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条PlansBatch
        /// </summary>
        /// <param name="model">种植计划实体</param>
        /// <returns></returns>
        public MessageModel UpdateSinglePlansBatch(PlansBatchModel model)
        {
            var data = plansBatchAccess.GetOriEntity(model.BatchID, model.ModifyTime);
            if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return plansBatchAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条PlansBatch
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSinglePlansBatch(int id)
        {
            return plansBatchAccess.DeleteSingleEntity(id);
        }

        public PlansBatchModel GetPlansBatchByEPCOrORCode(string Epc, string OrCode)
        {
            PlansBatchAccess access = new PlansBatchAccess();
            return access.GetPlansBatchByEPCOrORCode(Epc, OrCode);
        }
        //private void SetLandBlock(PlansBatchModel model)
        //{
        //    if (model.BlockID.HasValue)
        //        model.LandBlock = landBlockAccess.GetEntityById(model.BlockID.Value);
        //}

        //private void SetSeedBase(PlansBatchModel model)
        //{
        //    if (model.SeedID.HasValue)
        //        model.SeedBase = seedBaseAccess.GetEntityById(model.SeedID.Value);
        //}
    }
}

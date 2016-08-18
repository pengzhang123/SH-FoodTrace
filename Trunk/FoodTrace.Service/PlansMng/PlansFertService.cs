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
using FoodTrace.Model.BaseDto;
using FoodTrace.Model.DtoModel;

namespace FoodTrace.Service
{
    /// <summary>
    /// 施肥管理
    /// </summary>
    public class PlansFertService : BaseService, IPlansFertService
    {
        private IPlansFertAccess plansFertAccess;
        private IPlansBatchAccess plansBatchAccess;

        public PlansFertService()
        {
            plansFertAccess = BaseAccess.CreateAccess<IPlansFertAccess>(AccessMappingKey.PlansFertAccess.ToString());
            plansBatchAccess = BaseAccess.CreateAccess<IPlansBatchAccess>(AccessMappingKey.PlansBatchAccess.ToString());
        }

        /// <summary>
        /// 获取PlansFert总条数
        /// </summary>
        /// <returns></returns>
        public int GetPlansFertCount()
        {
            return plansFertAccess.GetEntityCount();
        }

        /// <summary>
        /// 获取PlansFert总条数
        /// </summary>
        /// <param name="code">查询条件：溯源码（模糊查询）</param>
        /// <returns></returns>
        public int GetPlansFertCount(string code)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            return plansFertAccess.GetEntityCount(companyID, code.Trim());
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="name">查询条件：溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        public List<PlansFertModel> GetPagerPlansFert(string code, int pageIndex, int pageSize)
        {
            int companyID = UserManagement.CurrentUser.CompanyId;
            var result = plansFertAccess.GetPagerPlansFertByConditions(companyID, code.Trim(), pageIndex, pageSize);
            //result.ForEach(m => SetPlansBatch(m));
            return result;
        }

        /// <summary>
        /// 通过ID获取PlansFert
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlansFertModel GetPlansFertById(int id)
        {
            return plansFertAccess.GetEntityById(id);
        }

        /// <summary>
        /// 新增单条PlansFert
        /// </summary>
        /// <param name="model">施肥信息实体</param>
        /// <returns></returns>
        public MessageModel InsertSinglePlansFert(PlansFertModel model)
        {
            return plansFertAccess.InsertSingleEntity(model);
        }

        /// <summary>
        /// 编辑单条PlansFert
        /// </summary>
        /// <param name="model">施肥信息实体</param>
        /// <returns></returns>
        public MessageModel UpdateSinglePlansFert(PlansFertModel model)
        {
            //var data = plansFertAccess.GetOriEntity(model.FertID, model.ModifyTime);
            //if (data == null) return new MessageModel() { Message = "当前数据不存在或被更新，请刷新后再次操作！", Status = MessageStatus.Error };
            return plansFertAccess.UpdateSingleEntity(model);
        }

        /// <summary>
        /// 删除单条PlansFert
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public MessageModel DeleteSinglePlansFert(int id)
        {
            return plansFertAccess.DeleteSingleEntity(id);
        }

        //private void SetPlansBatch(PlansFertModel model)
        //{
        //    if (model.BatchID.HasValue)
        //        model.PlansBatch = plansBatchAccess.GetEntityById(model.BatchID.Value);
        //}

        /// <summary>
        /// 数据分页
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pIndex"></param>
        /// <param name="pSize"></param>
        /// <returns></returns>
        public GridList<PlansFertDto> GetPlansFertPagingList(string name, int pIndex, int pSize)
        {
            return plansFertAccess.GetPlansFertPagingList(string.Empty, pIndex, pSize);
        }

        /// <summary>
        /// 根据id获取数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PlansFertDto GetFerDtoById(int id)
        {
            return plansFertAccess.GetFerDtoById(id);
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public MessageModel DeleteByIds(string ids)
        {
            return plansFertAccess.DeleteByIds(ids);
        }
    }
}

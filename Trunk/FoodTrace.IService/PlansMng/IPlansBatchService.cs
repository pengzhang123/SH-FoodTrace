using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 种植计划管理
    /// </summary>
    public interface IPlansBatchService
    {
        /// <summary>
        /// 获取PlansBatch总条数
        /// </summary>
        /// <returns></returns>
        int GetPlansBatchCount();

        /// <summary>
        /// 获取PlansBatch总条数
        /// </summary>
        /// <param name="code">查询条件：批次溯源码（模糊查询）</param>
        /// <returns></returns>
        int GetPlansBatchCount(string code);

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="name">查询条件：批次溯源码（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<PlansBatchModel> GetPagerPlansBatch(string code, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取PlansBatch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PlansBatchModel GetPlansBatchById(int id);

        /// <summary>
        /// 新增单条PlansBatch
        /// </summary>
        /// <param name="model">种植计划实体</param>
        /// <returns></returns>
        MessageModel InsertSinglePlansBatch(PlansBatchModel model);

        /// <summary>
        /// 编辑单条PlansBatch
        /// </summary>
        /// <param name="model">种植计划实体</param>
        /// <returns></returns>
        MessageModel UpdateSinglePlansBatch(PlansBatchModel model);

        /// <summary>
        /// 删除单条PlansBatch
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSinglePlansBatch(int id);
        PlansBatchModel GetPlansBatchByEPCOrORCode(string Epc, string OrCode);
    }
}

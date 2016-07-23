using FoodTrace.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.IService
{
    /// <summary>
    /// 加工厂接收待加工订单信息管理
    /// </summary>
    public interface IProcessBatchService
    {
        /// <summary>
        /// 获取ProcessBatch总条数
        /// </summary>
        /// <returns></returns>
        int GetProcessBatchCount();

        /// <summary>
        /// 获取ProcessBatch总条数
        /// </summary>
        /// <param name="batchNo">查询条件：批次编号（模糊查询）</param>
        /// <returns></returns>
        int GetProcessBatchCount(string batchNo);

        /// <summary>
        /// 获取当前用户所在公司的待加工订单信息（分页）
        /// </summary>
        /// <param name="batchNo">查询条件：批次编号（模糊查询）</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns></returns>
        List<ProcessBatchModel> GetPagerProcessBatch(string batchNo, int pageIndex, int pageSize);

        /// <summary>
        /// 通过ID获取ProcessBatch
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProcessBatchModel GetProcessBatchById(int id);

        /// <summary>
        /// 新增单条ProcessBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel InsertSingleProcessBatch(ProcessBatchModel model);

        /// <summary>
        /// 编辑单条ProcessBatch
        /// </summary>
        /// <param name="model">地块信息实体</param>
        /// <returns></returns>
        MessageModel UpdateSingleProcessBatch(ProcessBatchModel model);

        /// <summary>
        /// 删除单条ProcessBatch
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        MessageModel DeleteSingleProcessBatch(int id);
    }
}
